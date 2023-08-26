# Use-case generator

> Use-case first development: first create the use-case specification and then create the adapter specification which exposes the use-case.

With use-case first development instead of API first development we are solving the following problems:

1. **API blind spots**: Not all use-cases are exposed via a REST API.
2. **Manual use-case generation**: Use-cases are created manually introducing the risk that they do not align with business (requirements).  
3. **Mapping hell**: Because the API generated models live in an adapter layer they cannot be used in the domain layer. The same models need to be created in, and mapped to, the domain layer resulting in unnecessary use of scarce development resources.

## Solution

The code generator parses a YAML file which contain a use-case description. Json-schema is used to specify the use-case parameters and response. The parsed use-case specification is used to generate the use-case interface as well as the parameter and response models.

```yaml
name: use case 1
description: a description
parameters:
  param1:
    type: string
  param2:
    $ref: "./param2.yml" 
response:
  $ref: "./response.yml" 
```

OpenAPI schemas reference the use-case schemas so that the OpenAPI generator can use the domain models as parameters or create mapping code to map the adapter models to the domain models. With that code in place, it is possible to create also an implementation of the generated interface which executes the use-case.

```yaml
penapi: 3.0.3

info:
  version: 0.0.1
  title: API
paths:

  /resources/{filter}:
    parameters:
      - in: path
        name: filter
        required: true
        schema:
          $ref: "./get-resources.use-case.yml#/parameters/filter"
    get:
      tags:
        - resources
      summary: Retrieves resources.
      operationId: GetResources
      parameters:
        - in: query
          name: limit
          required: false
          schema:
            $ref: "./get-resources.use-case.yml#/parameters/limit"
        - in: query
          name: offset
          required: false
          schema:
            $ref: "./get-resources.use-case.yml#/parameters/offset"
      responses:
        200:
          description: OK
          content:
            application/json:
              schema:
                $ref: "./get-resources.use-case.yml#/response"
```

## Convention

1. File name is the use-case name;
2. Use-case name can be overwritten by the name property in YAML file.
3. Parameters and response are optional.
4. Use-case is a command when there is no response specified;
5. Use-case is a query when a response is specified;
6. Parameters is a key / value collection. The value is a Json-schema basic type.
7. Response is a Json-schema basic type.

## Requirements

* Use node.js for development;
* Support recursive references;
* Implement AllOf convention: 
  * If there are one or two objects, the first object is the base class.
  * If there are more than two objects, create a new type. 
* Implement OneOf convention: 
  * Find the shared base type and use that type as the parameter type.
  * Generate inline use-case documentation which specify the possible implementations of the parameter (or create new base type because it is possible that not all implementations are allowed?). 
* Linting support to detect where the API schema and use-case scheme does not allign.
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