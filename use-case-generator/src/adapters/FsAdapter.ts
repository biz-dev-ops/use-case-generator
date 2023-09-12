import { access, constants, readdir, readFile, stat } from 'node:fs/promises';
import { parse, join } from "node:path";
import { load } from "js-yaml";

import { File, GetFileReferencePort } from '../ports/GetFileReference';
import { GetUseCaseFilesPort } from '../ports/GetUseCaseFiles';

export class FsAdapter implements GetFileReferencePort, GetUseCaseFilesPort {
    async getFileReference(path: string): Promise<File> {
        await access(path, constants.R_OK);

        if(!(await stat(path)).isFile())
            throw new Error(`Path is not a file: ${path}`);

        return new FsFile(path);
    }

    async getUseCaseFiles(path: string): Promise<string[]> {
        const useCaseFiles: string[] = [];

        if((await stat(path)).isDirectory()) {
            const entries = await readdir(path, { withFileTypes: true });

            for (let entry of entries) {
                if(entry.isDirectory() || entry.name.endsWith(".use-case.yml")) {
                    useCaseFiles.push(...await this.getUseCaseFiles(join(entry.path, entry.name)));
                }
            }
        }
        else if(path.endsWith(".use-case.yml")) {
            useCaseFiles.push(path);
        }

        return useCaseFiles;
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
        let content = await this.readString();
        if(this.extension.endsWith(".yml") || this.extension.endsWith(".yaml")) {
            return load(content) || {};
        }
        else {
            return JSON.parse(content);
        }
    }

    async readType<T>() : Promise<T> {
        return this.readJson() as T
    }
}