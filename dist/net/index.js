"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const schematics_1 = require("@angular-devkit/schematics");
const core_1 = require("@angular-devkit/core");
const frameworkDependencies = {
    'netcoreapp2.2': {
        mvc: {
            version: '2.2.0'
        }
    }
};
const loggingConfigurations = {
    'log4net': 'log4net.config',
    'serilog': 'appsettings-serilog.json',
    'nlog': 'NLog.config'
};
function uuid() {
    var uuid = "", i, random;
    for (i = 0; i < 32; i++) {
        random = Math.random() * 16 | 0;
        if (i == 8 || i == 12 || i == 16 || i == 20) {
            uuid += "-";
        }
        uuid += (i == 12 ? 4 : (i == 16 ? (random & 3 | 8) : random)).toString(16);
    }
    return uuid;
}
function net(_options) {
    return (_, _context) => {
        const guids = {};
        const [name, ...reversePath] = _options.name.split(/[\\/]/gm).reverse();
        const path = reversePath.reverse().join('/');
        const sourceTemplates = schematics_1.url('./files');
        const genconfig = Object.assign({}, frameworkDependencies[_options.framework], _options, { loggingConfig: loggingConfigurations[_options.logging], name });
        const parameterizedSourceTemplates = schematics_1.apply(sourceTemplates, [
            schematics_1.template(Object.assign({}, core_1.strings, genconfig, { genconfig: JSON.stringify(genconfig), guid: (key) => guids[key] = guids[key] || uuid() })),
            schematics_1.move('', path)
        ]);
        const result = schematics_1.mergeWith(parameterizedSourceTemplates);
        return result;
    };
}
exports.net = net;
//# sourceMappingURL=index.js.map