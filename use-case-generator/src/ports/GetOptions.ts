export interface GetOptionsPort {
    getOptions() : Promise<Options>
}

export class Options {
    language: LanguageOption;
    source: string;
    destination: string;
    loglevel: LoglevelOption;
    
    constructor(language: LanguageOption, source: string, destination: string, loglevel: LoglevelOption)  {
        this.language = language;
        this.source = source;
        this.destination = destination;
        this.loglevel = loglevel ?? LoglevelOption.Warn;
    }
}

export enum LanguageOption {
    "C#" = "C#",
    Java = "Java"
};

export enum LoglevelOption {
    Fatal = "Fatal", 
    Error = "Error", 
    Warn = "Error", 
    Info = "Info", 
    Debug = "Debug", 
    Trace = "Trace"
};