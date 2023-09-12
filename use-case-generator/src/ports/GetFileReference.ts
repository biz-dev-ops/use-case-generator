export interface GetFileReferencePort {
    getFileReference(path: string) : Promise<File> 
}

export interface File {
    readonly name: string;
    readonly extension: string;

    readString() : Promise<string>;
    readJson() : Promise<any>;
    readType<T>() : Promise<T>
}