import { access, constants, lstat } from 'node:fs/promises';
import { readFile } from 'node:fs/promises';
import { parse } from "node:path";
import { File, GetFileReferencePort } from '../ports/GetFileReference';

export class FsAdapter implements GetFileReferencePort {
    
    async getFileReference(path: string): Promise<File> {
        await access(path, constants.R_OK);

        if(!(await lstat(path)).isFile())
            throw new Error(`Path is not a file: ${path}`);

        return new FsFile(path);
    }
}

export class FsFile implements File {
    path: string;
    name: string;
    extension: string;
    
    constructor(path: string) {
       this.path = path;
       const parts = parse(path);
       this.name = parts.name;
       this.extension = parts.ext;
    }

    async readString() : Promise<string> {
       return readFile(this.path, { encoding: 'utf-8'})
    }

    async readJson() : Promise<any> {
        const jsonString = await this.readString();
        return JSON.parse(jsonString);
    }

    async readType<T>() : Promise<T> {
        return this.readJson() as T
    }
}