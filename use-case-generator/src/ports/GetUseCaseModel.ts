import { GetFileReferencePort } from './GetFileReference';
import UseCaseModel from '../domain/UseCaseModel';

export interface GetUseCaseModelPort {
    getUseCaseModel(path: string) : Promise<UseCaseModel>;
}

export class GetUseCaseModelPortImpl implements GetUseCaseModelPort {
    private getFileReferencePort: GetFileReferencePort;
    
    constructor(getFileReferencePort: GetFileReferencePort) {
        this.getFileReferencePort =  getFileReferencePort;
    }
    
    async getUseCaseModel(path: string): Promise<UseCaseModel> {
        const file = await this.getFileReferencePort.getFileReference(path);
        const json = await file.readJson();
        json.name = json.name || file.name;
        return new UseCaseModel(json);
    }

}