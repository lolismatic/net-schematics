import {
    Rule,
    SchematicContext,
    Tree,
    template,
    apply,
    url,
    mergeWith
} from '@angular-devkit/schematics';
import { strings } from '@angular-devkit/core';
import * as fs from 'fs';


export function netCommand(_options: any): Rule {
    return (_: Tree, _context: SchematicContext) => {
        const config = JSON.parse(fs.readFileSync('.genconfig', 'utf8'));

        console.log({config});

        const sourceTemplates = url('./files');

        const parameterizedSourceTemplates = apply(sourceTemplates, [
            template({
                ..._options,
                ...strings,
                name
            })
        ]);

        const result = mergeWith(parameterizedSourceTemplates);

        return result;
    };
}
