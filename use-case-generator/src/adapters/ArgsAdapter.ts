import yargs from 'yargs';
import { hideBin } from 'yargs/helpers';

import { GetOptionsPort, LoglevelOption, Options } from "../ports/GetOptions";
import { CodeLanguage } from '../domain/Enums';

export class ArgsAdapter implements GetOptionsPort {
    private options?: Options;

    async getOptions(): Promise<Options> {
        if(this.options)
            return this.options;

        const args = await getArgs();
        this.options = this.map(args);
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

    private mapLanguage(language: string) : CodeLanguage {
       return CodeLanguage[language as keyof typeof CodeLanguage];
    }

    private mapLogLevel(logLevel: string) : LoglevelOption {
        return LoglevelOption[logLevel as keyof typeof LoglevelOption];
    }
}

interface Args {
    readonly language: string;
    readonly source: string;
    readonly destination: string
    readonly loglevel: string
}

const getArgs = async () : Promise<Args> => {
    const args = await yargs(hideBin(process.argv))
        .option("language", {
            alias: [ "lang", "l" ],
            describe: "Define code language to generate.",
            type: "string",
            choices: Object
                .keys(CodeLanguage)
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
        .argv;

    return args as Args;
}