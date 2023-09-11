const awilix = require('awilix');
const { asClass, asValue } = require('awilix');

const Logger = require("../utils/logger");

module.exports = class App {
    constructor(args) {
        this.container = awilix.createContainer({
            injectionMode: awilix.InjectionMode.PROXY
        });
        
        this._registerServices({
            "options": asValue(parseArgs(args)),
            "logger": asClass(Logger).singleton()
        });

        this.logger = this.container.resolve('logger');
    }

    async run() {
        this.logger.info("hello world!");
        throw new Error("test");
    }

    async dispose() {
        this.container.dispose();
        this.container = null;

        this.logger.info("disposed");
    }

    _registerServices(services) {
        const parsed = {};

        const parse = (resolver) => {
            if (Array.isArray(resolver))
                return asArray(resolver);    
            
            if (!resolver.disposer)
                return resolver;
            
            return resolver.disposer?.(async service => await service.dispose?.());
        }
    
        for (const [key, value] of Object.entries(services)) {
            parsed[key] = parse(value);
        }
    
        this.container.register(parsed);
    }
};

const parseArgs = function(args) {
    return {
        language: args.language,
        source: args.source,
        destination: args.destination,
        loglevel: args.loglevel
    }
}