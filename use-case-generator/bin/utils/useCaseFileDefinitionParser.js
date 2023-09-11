const path = require("path");

module.exports = class UseCaseFileDefinitionParser {
    async parse(source, parser) {
        //If source is file, parse file and execute parser
        //If source is directory, recursivly find evert *.use-case.yml, parse file and execute parser
    }
};