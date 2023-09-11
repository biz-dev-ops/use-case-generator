const { createContainer, asValue, Lifetime } = require("awilix")

module.exports = class App {
    constructor(args) {
        this.container = initContainer(parseArgs(args));
        this.logger = this.container.resolve("logger");
    }

    async run() {
        this.logger.info("hello %s!", "world");
    }

    async dispose() {
        this.logger.info("Disposing app.");

        await this.container.dispose();
        this.container = null;

        this.logger.info("App is disposed.");

        this.logger = null
    }
};

const initContainer = (options) => createContainer()
    .register("options", asValue(options))
    .loadModules([
        "utils/*.js"
    ], {
        resolverOptions: {
            lifetime: Lifetime.SINGLETON,
            dispose: async (service) => await service.dispose?.()
        }
    });

const parseArgs = function(args) {
    return {
        language: args.language,
        source: args.source,
        destination: args.destination,
        loglevel: args.loglevel
    }
}