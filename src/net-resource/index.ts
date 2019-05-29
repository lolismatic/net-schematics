import {
    Rule,
    SchematicContext,
    Tree,
    template,
    apply,
    url,
    mergeWith,
    move
} from '@angular-devkit/schematics';
import { strings } from '@angular-devkit/core';

export function netResource(_options: any): Rule {
    return (_: Tree, _context: SchematicContext) => {
        const [name, ...reversePath] = _options.name.split(/[\\/]/gm).reverse();
        const path = reversePath.reverse().join('/');

        const commands = [{
            name: 'CreateBook',
            method: 'Post',
            response: 'Book',
            references: [`${strings.classify(name)}.Domain`]
        }]

        const queries = [{
            name: 'GetBook',
            method: 'Get',
            route: '{id}',
            response: 'Book',
            references: [`${strings.classify(name)}.Domain`]
        }]

        const commandReferences =
            commands.reduce((acc, cur) => ([...new Set([...acc, ...cur.references])]), []);

        const queryReferences =
            queries.reduce((acc, cur) => ([...new Set([...acc, ...cur.references])]), [])

        // console.log({commandReferences, queryReferences, commands, queries})

        const sourceTemplates = url('./files');

        const parameterizedSourceTemplates = apply(sourceTemplates, [
            template({
                ..._options,
                ...strings,
                commands, queries,
                commandReferences, queryReferences,
                name
            }),
            move('', path)
        ]);

        const result = mergeWith(parameterizedSourceTemplates);

        return result;
    };
}
