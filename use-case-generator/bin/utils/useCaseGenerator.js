const path = require("path");

module.exports = class UseCaseGenerator {
    constructor({ options, typeGenerator, interfaceGenerator, logger }) { 
        this.options = options;
        this.typeGenerator = typeGenerator;
        this.interfaceGenerator = interfaceGenerator;
        this.logger = logger;
    }

    async generate(useCase) {
        const destination = path.join(this.destination, path.relative(this.options.source, useCase.source));
        const parametersType = await this.typeGenerator.generate(this.options.language, useCase.parameters, destination);
        const responseType = await this.typeGenerator.generate(this.options.language, useCase.response, destination);
        const interfaceType = await this.interfaceGenerator.generate(this.options.language, useCase.name, parametersType, responseType, destination);
        
        return interfaceType;
    }

    async dispose() {
        this.logger = null
    }
};