import { CodeLanguage } from "../domain/Enums";

export interface GetOptionsPort {
    getOptions() : Promise<Options>
}

export class Options {
    readonly language: CodeLanguage;
    readonly source: string;
    readonly destination: string;
    readonly loglevel: LoglevelOption;
    
    constructor(language: CodeLanguage, source: string, destination: string, loglevel: LoglevelOption)  {
        this.language = language;
        this.source = source;
        this.destination = destination;
        this.loglevel = loglevel ?? LoglevelOption.Warn;
    }
}

export enum LoglevelOption {
    Fatal = "Fatal", 
    Error = "Error", 
    Warn = "Error", 
    Info = "Info", 
    Debug = "Debug", 
    Trace = "Trace"
};
