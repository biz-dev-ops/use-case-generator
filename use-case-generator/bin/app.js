module.exports = class App {
    constructor({ logger }) { 
        this.logger = logger;
    }

    async run() {
        this.logger.info("App is %s.", "running");
    }

    async dispose() {
        this.logger.info("Disposing app.");
        this.logger.info("App is disposed.");
        this.logger = null
    }
};