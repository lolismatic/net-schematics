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

const frameworkDependencies: any = {
    'netcoreapp2.2': {
        mvc: {
            version: '2.2.0'
        }
    }
};

const loggingConfigurations: any = {
    'log4net': 'log4net.config',
    'serilog': 'appsettings-serilog.json',
    'nlog': 'NLog.config'
};

function uuid() {
    var uuid = "", i, random;

    for (i = 0; i < 32; i++) {
        random = Math.random() * 16 | 0;

        if (i == 8 || i == 12 || i == 16 || i == 20) {
            uuid += "-"
        }
        uuid += (i == 12 ? 4 : (i == 16 ? (random & 3 | 8) : random)).toString(16);
    }

    return uuid;
}

export function net(_options: any): Rule {
    return (_: Tree, _context: SchematicContext) => {
        const guids: { [key: string]: any } = {};

        const [name, ...reversePath] = _options.name.split(/[\\/]/gm).reverse();
        const path = reversePath.reverse().join('/');

        const sourceTemplates = url('./files');
        const genconfig = {
            ...frameworkDependencies[_options.framework],
            ..._options,
            loggingConfig: loggingConfigurations[_options.logging],
            name
        };

        const parameterizedSourceTemplates = apply(sourceTemplates, [
            template({
                ...strings,
                ...genconfig,
                genconfig: JSON.stringify(genconfig),
                guid: (key: string) => guids[key] = guids[key] || uuid()
            }),
            move('', path)
        ])

        const result = mergeWith(parameterizedSourceTemplates);

        return result;
    };
}
