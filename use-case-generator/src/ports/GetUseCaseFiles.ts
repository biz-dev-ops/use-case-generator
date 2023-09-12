export interface GetUseCaseFilesPort {
    getUseCaseFiles(path: string) : Promise<string[]>
}