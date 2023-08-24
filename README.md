# Use-case generator

> Use-case first development: first create the use-case specification and secondly create an Open API specification which references the use-case parameters. 

The generator parses a YAML file which contain a use-case description. Json-schema is used to specify the use-case parameters. The parsed use-case specification is used to generate the use-case interface as well as the parameter models.

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

## Convention

1. File name is the use-case name;
2. Use-case name can be overwritten by the name property in YAML file.
3. Parameters and response are optional.
4. Use-case is a command when there is no response specified;
5. Use-case is a query when a response is specified;
6. Parameters is a key / value collection. The value is a json-schema basic type.
7. Response is a json-schema basic type.

## Requirements

* Use node.js for development;
* Support recursive references;
* Implement AllOf convention: 
  * If there are exactly two objects, the first object is the base class.
  * If there are more than two objects, create a new type. 
* Implement AnyOf convention: 
  * Find the shared base type and use that type as the parameter type.
  * Generate inline use-case documentation which specify the possible implementations of the parameter. 
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

* json-schema bundling: https://apitools.dev/json-schema-ref-parser/docs/ref-parser.html
* multi-language type generator: https://github.com/quicktype/quicktype/blob/master/FAQ.md