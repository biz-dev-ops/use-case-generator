export interface GetOptionsPort {
    getOptions() : Options
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
    "C#",
    Java
};

export enum LoglevelOption {
    Fatal, 
    Error, 
    Warn, 
    Info, 
    Debug, 
    Trace
};