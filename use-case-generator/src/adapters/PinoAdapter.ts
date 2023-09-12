import pino, { Logger } from "pino";
import { LogMesssagePort } from "../ports/LogMessage";
import { GetOptionsPort, LoglevelOption } from "../ports/GetOptions";

export default class PinoAdapter implements LogMesssagePort {
    logger?: Logger;

    constructor(getOptionsPort: GetOptionsPort) {
        const options = getOptionsPort.getOptions().then((options) => {
            this.logger = pino({
                level: map(options.loglevel),
                transport: {
                    target: "pino-pretty"
                }
            });
        });

        process.on("uncaughtException", (err: string) => {
            this.fatal(err);
            process.exit(1);
        });

        process.on("unhandledRejection", (err: string) => {
            this.fatal(err);
            process.exit(1);
        });
    }

    fatal(message: string, ...interpolationValues: any[]): void { this.logger?.fatal(message, ...interpolationValues); }

    error(message: string, ...interpolationValues: any[]): void { this.logger?.error(message, ...interpolationValues); }

    warn(message: string, ...interpolationValues: any[]): void { this.logger?.warn(message, ...interpolationValues); }

    info(message: string, ...interpolationValues: any[]): void { this.logger?.info(message, ...interpolationValues); }

    debug(message: string, ...interpolationValues: any[]): void { this.logger?.debug(message, ...interpolationValues); }

    trace(message: string, ...interpolationValues: any[]): void { this.logger?.trace(message, ...interpolationValues); }
}

const map = function (loglevel: LoglevelOption): string {
    switch (loglevel) {
        case LoglevelOption.Debug:
            return "debug";
        case LoglevelOption.Error:
            return "error";
        case LoglevelOption.Fatal:
            return "fatal";
        case LoglevelOption.Info:
            return "info";
        case LoglevelOption.Trace:
            return "trace";
        case LoglevelOption.Warn:
            return "warn";
    }
}