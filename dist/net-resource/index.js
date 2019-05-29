"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const core_1 = require("@angular-devkit/core");
function netResource(_options) {
    return (_, _context) => {
        const [name, ...reversePath] = _options.name.split(/[\\/]/gm).reverse();
        const path = reversePath.reverse().join('/');
        const commands = [{
                name: 'CreateBook',
                method: 'Post',
                response: 'Book',
                references: [`${core_1.strings.classify(name)}.Domain`]
            }];
        const queries = [{
                name: 'GetBook',
                method: 'Get',
                route: '{id}',
                response: 'Book',
                references: [`${core_1.strings.classify(name)}.Domain`]
            }];
        const commandReferences = commands.reduce((acc, cur) => ([...new Set([...acc, ...cur.references])]), []);
        const queryReferences = queries.reduce((acc, cur) => ([...new Set([...acc, ...cur.references])]), []);
        // console.log({commandReferences, queryReferences, commands, queries})
        const sourceTemplates = schematics_1.url('./files');
        const parameterizedSourceTemplates = schematics_1.apply(sourceTemplates, [
            schematics_1.template(Object.assign({}, _options, core_1.strings, { commands, queries,
                commandReferences, queryReferences,
                name })),
            schematics_1.move('', path)
        ]);
        const result = schematics_1.mergeWith(parameterizedSourceTemplates);
        return result;
    };
}
exports.netResource = netResource;
//# sourceMappingURL=index.js.map