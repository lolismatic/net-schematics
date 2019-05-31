import { Rule, SchematicContext, Tree, template, apply, url, mergeWith, MergeStrategy, forEach } from '@angular-devkit/schematics';
import { strings, template as templateImpl } from '@angular-devkit/core';
import { from, of, Observable } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';
import * as fs from 'fs';
import * as inquirer from 'inquirer';
import autocompletePrompt from 'inquirer-autocomplete-prompt';
import glob from 'glob';
import pluralize from 'pluralize';

const csharp = {
    class: (name: string) => {
        return ({
            start: (content: string) => {
                const patt = `class *${name} *(.|\r?\n)*?{`;
                const match = new RegExp(patt).exec(content) as RegExpExecArray;

                return match.index + match[0].length;
            },
            end: (content: string) => {
                const patt = `class *${name} (.|\r?\n)*?{(?:\{([^\{\}]|\r?\n)*\}|[^\{\}]|\r?\n)*(?=(?:    }))`;
                const match = new RegExp(patt).exec(content) as RegExpExecArray;

                return match.index + match[0].length;
            }
        })
    }
};

class Old {
    private _content: string;

    constructor(content: string) {
        this._content = content;
    }

    popUntil(matcher: (content: string) => number): string {
        const pop = matcher(this._content);

        const popped = this._content.slice(0, pop);

        this._content = this._content.slice(pop, this._content.length);

        return popped;
    }

    popAll(): string {
        const popped = this._content;

        this._content = '';

        return popped;
    }

    isEmpty() {
        return this._content.length === 0;
    }
}

inquirer.registerPrompt('autocomplete', autocompletePrompt as any);

function getResources(): Promise<any[]> {
   return new Promise(resolve => {
        glob('src/*.Api/**/*Controller.cs', (_, matches) => {
            const matchMap = matches
                .map(match => match.split(/\\|\//g).reverse()[0].slice(0, -('Controller.cs'.length)))
                .filter(resourceName => resourceName !== 'Base')
                .map(resourceName => {
                    return { value: resourceName, name: resourceName };
                });

            resolve(matchMap);
        })
   })
}

async function getOptions(): Promise<any> {
    const resources = await getResources();

    return await inquirer.prompt([{
        type: 'autocomplete',
        name: 'resource',
        message: 'Resource name:',
        source: function(_: any, input: any) {
            return of(resources.filter(({name}) => !input || name.includes(input)))
                .toPromise();
        },
        suggestOnly: true
    } as any, {
        type: 'list',
        name: 'commandMethod',
        message: 'Http method:',
        choices: ['Post', 'Delete', 'Put', 'Patch']
    }, {
        type: 'string',
        name: 'commandName',
        message: 'Name:',
        default: ({commandMethod, resource}: any) => {
            return commandMethod + pluralize.singular(resource);
        }
    }, {
        type: 'string',
        name: 'commandRoute',
        message: 'Http route:',
        default: ({commandMethod}) => commandMethod in ['Delete', 'Patch', 'Put'] ? '{id}': ''
    }, {
        type: 'string',
        name: 'commandResponse',
        message: 'Response type:',
        default: ({commandMethod, resource}) => commandMethod === 'Post' ? pluralize.singular(resource) : 'void'
    }]);
}

const conflicts: any[] = [];

export function netCommand(_: any): Rule {
    return (tree: Tree, context: SchematicContext) => {
        return from(getOptions())
            .pipe(
                switchMap(options => {
                    let index = 0;
                    const config = JSON.parse(fs.readFileSync('.genconfig', 'utf8'));
                    const sourceTemplates = url('./files/templates');
                    const templates: string[] = [];

                    const parameterizedSourceTemplates = apply(sourceTemplates, [
                        forEach(file => {
                            templates.push(file.path);

                            return file;
                        }),
                        template({
                            ...config,
                            ...options,
                            ...strings
                        }),
                        forEach(file => {
                            if (tree.exists(file.path)) {
                                conflicts.push({
                                    override: templates[index],
                                    path: file.path
                                });

                                return null;
                            }

                            index++;
                            return file;
                        })
                    ]);

                    return (mergeWith(parameterizedSourceTemplates, MergeStrategy.AllowCreationConflict)(tree, context) as Observable<Tree>)
                        .pipe(map(latestTree => <[Tree, any, any]>[latestTree, options, config]));
                }),
                switchMap(([latestTree, options, config]) => {
                    const source = apply(
                        url('./files/overrides'), [
                            forEach(file => {
                                const conflict = conflicts.find(c => c.override === file.path);

                                if (!conflict) {
                                    console.log('No conflict!');

                                    return null;
                                }

                                console.log('Will execute template!');

                                const old = new Old(
                                    (tree.read(conflict.path) as any).toString('utf8')
                                );

                                const { content } = file;

                                latestTree.overwrite(conflict.path, Buffer.from(templateImpl(content.toString('utf-8'), {})({
                                    ...config, ...options, ...strings,
                                    old, csharp
                                  })));

                                return null;
                            })
                        ]);

                    return mergeWith(source)
                        (latestTree, context) as Observable<Tree>;
                })
            );
    };
}
