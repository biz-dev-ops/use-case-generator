
module.exports = class App {
    constructor({ options, useCaseParser: useCaseFileDefinitionParser, useCaseGenerator, logger }) { 
        this.options = options;
        this.useCaseFileDefinitionParser = useCaseFileDefinitionParser;
        this.useCaseGenerator = useCaseGenerator;
        this.logger = logger;
    }

    async run() {
        await this.useCaseFileDefinitionParser.parse(this.options.source, async (useCase) => {
            const useCaseType = this.useCaseGenerator.generate(this.options.language, useCase);
            this.useCaseMapper.add(useCase, useCaseType);
        });

        await this.useCaseMapper.writeToFile(path.join(this.options.destination, "use-case-mapping.yml"));
    }

    async dispose() {
        this.logger = null
    }
};