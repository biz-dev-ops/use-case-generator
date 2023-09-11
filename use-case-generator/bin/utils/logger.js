const pino = require("pino");

module.exports = class Logger {
    constructor({ options }) {
        this.logger = pino({
            level: options?.loglevel,
            transport: {
                target: "pino-pretty"
            }
        });

        process.on("uncaughtException", (err) => {
            this.logger.fatal(err);
            process.exit(1);
        });
        
        process.on("unhandledRejection", (err) => {
            this.logger.fatal(err);
            process.exit(1);
        });
    }

    fatal(message, ...interpolationValues) { this.logger.fatal(message, ...interpolationValues); }
    error(message, ...interpolationValues) { this.logger.error(message, ...interpolationValues); }
    warn(message, ...interpolationValues) { this.logger.warn(message, ...interpolationValues); }
    info(message, ...interpolationValues) { this.logger.info(message, ...interpolationValues); }
    debug(message, ...interpolationValues) { this.logger.debug(message, ...interpolationValues); }
    trace(message, ...interpolationValues) { this.logger.trace(message, ...interpolationValues); }

    async dispose() {
        this.logger.info("logger disposed!");
    }
}