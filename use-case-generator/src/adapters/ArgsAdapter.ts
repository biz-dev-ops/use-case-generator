import yargs from 'yargs';
import { hideBin } from 'yargs/helpers';

import { GetOptionsPort, LanguageOption, LoglevelOption, Options } from "../ports/GetOptions";

export class ArgsAdapter implements GetOptionsPort {
    private options: Options ;

    constructor() {
        const args = getArgs();
        this.options = this.map(args);
    }
    
    getOptions(): Options {
        return this.options;
    }

    private map(args: Args) : Options {
        return new Options(
            this.mapLanguage(args.language), 
            args.source,
            args.destination,
            this.mapLogLevel(args.loglevel)
        );
    }

    private mapLanguage(language: string) : LanguageOption {
       return LanguageOption[language as keyof typeof LanguageOption];
    }

    private mapLogLevel(logLevel: string) : LoglevelOption {
        return LoglevelOption[logLevel as keyof typeof LoglevelOption];
    }
}

interface Args {
    language: string;
    source: string;
    destination: string
    loglevel: string
}

const getArgs = () : Args => {
    const args = yargs(hideBin(process.argv))
        .option("language", {
            alias: [ "lang", "l" ],
            describe: "Define code language to generate.",
            type: "string",
            choices: Object
                .keys(LanguageOption)
                .filter((v) => isNaN(Number(v))),
            demandOption: true
        })
        .option("source", {
            alias: ["src", "s" ],
            describe: "The source use-case specification file or directory.",
            type: "string",
            demandOption: true
        })
        .option("destination", {
            alias: [ "dst", "d" ], 
            describe: "The destination directory where use-cases need to be genrated.",
            type: "string",
            demandOption: true
        })
        .option("loglevel", {
            alias: "ll",
            describe: "Define the log level.",
            type: "string",
            choices: Object
                .keys(LoglevelOption)
                .filter((v) => isNaN(Number(v))),
            default: LoglevelOption[LoglevelOption.Warn]
        })
        .parseSync();

    return args as Args;
}