# Use-case generator

> Use-case first development: first create the use-case specification and then create the adapter specification which exposes the use-case.

With use-case first development instead of API first development we are solving the following problems:

1. **API blind spots**: Not all use-cases are exposed via a REST API.
2. **Manual use-case generation**: Use-cases are created manually introducing the risk that they do not align with business (requirements).  
3. **Mapping hell**: Because the API generated models live in an adapter layer they cannot be used in the domain layer. The same models need to be created in, and mapped to, the domain layer resulting in unnecessary use of scarce development resources.

## Solution

...

## Requirements

* Use node.js for development;
* Support recursive references;
* Implement AllOf convention: 
  * If there are one or two objects, the first object is the base class.
  * If there are more than two objects, create a new type. 
* Implement OneOf convention: 
  * Find the shared base type and use that type as the parameter type.
  * Generate inline use-case documentation which specify the possible implementations of the parameter (or create new base type because it is possible that not all implementations are allowed?). 
* Linting support to detect where the API schema and use-case scheme does not align.
* Use open-source model generators if possible;
* Use open-source API generators if possible;
* Support hexagonal architecture;
* Create use-case and models in domain module;
* Expose use-case in API adapter module;
* Create best practice Java code;
* Create best practice C# code;
* Support easy code language extension;
* Support easy template overrides;

## Links

* Json-schema bundling: https://apitools.dev/json-schema-ref-parser/docs/ref-parser.html
* multi-language type generator: https://github.com/quicktype/quicktype/blob/master/FAQ.md