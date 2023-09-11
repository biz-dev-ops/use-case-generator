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

    fatal(message) { this.logger.fatal(message); }
    error(message) { this.logger.error(message); }
    warn(message) { this.logger.warn(message); }
    info(message) { this.logger.info(message); }
    debug(message) { this.logger.debug(message); }
    trace(message) { this.logger.trace(message); }
}