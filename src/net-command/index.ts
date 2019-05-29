import { Rule, SchematicContext, Tree, template, apply, url, mergeWith } from '@angular-devkit/schematics';
import { strings } from '@angular-devkit/core';
import { from, of, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import * as fs from 'fs';
import * as inquirer from 'inquirer';
import autocompletePrompt from 'inquirer-autocomplete-prompt';
import glob from 'glob';

inquirer.registerPrompt('autocomplete', autocompletePrompt as any);

function getResources(): Promise<any[]> {
   return new Promise(resolve => {
        glob('src/*.Api/*Controller.cs', (_, matches) => {
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
        type: 'string',
        name: 'commandName',
        message: 'Command name'
    }, {
        type: 'list',
        name: 'commandMethod',
        choices: ['Post', 'Delete', 'Put', 'Patch', 'Get']
    }, {
        type: 'string',
        name: 'commandRoute',
        message: 'Command route:'
    }, {
        type: 'string',
        name: 'commandResponse',
        message: 'Command response'
    }]);
}

export function netCommand(_: any): Rule {
    return (tree: Tree, context: SchematicContext) => {
        return from(getOptions())
            .pipe(
                switchMap(options => {
                    const config = JSON.parse(fs.readFileSync('.genconfig', 'utf8'));
                    const sourceTemplates = url('./files');

                    const parameterizedSourceTemplates = apply(sourceTemplates, [
                        template({
                            ...config,
                            ...options,
                            ...strings
                        })
                    ]);

                    return mergeWith(parameterizedSourceTemplates)(tree, context) as Observable<Tree>;
                })
        );
    };
}
