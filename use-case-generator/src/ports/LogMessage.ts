export interface LogMesssagePort {
    fatal(message: string, ...interpolationValues: any[]) : void;
    error(message: string, ...interpolationValues: any[]) : void;
    warn(message: string, ...interpolationValues: any[]) : void;
    info(message:string, ...interpolationValues: any[]) : void;
    debug(message: string, ...interpolationValues: any[]) : void;
    trace(message: string, ...interpolationValues: any[]) : void;
}