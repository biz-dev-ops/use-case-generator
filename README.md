# Use-case generator

> Use-case first development: first create the use-case specification and secondly create an Open API specification which references the use-case parameters. 

The generator parses a YAML file which contain a use-case description. Json-schema is used to specify the use-case parameters. The parsed use-case specification is used to generate the use-case interface as well as the parameter models.

```yaml
name: use case 1
description: a description
parameters:
  - title: param1
    type: string
  - $ref: "./param2.yml" 
```

## Requirements

* Support recursive references;
* Implement AllOf convention: 
  * If there are exactly two objects, the first object is the base class.
  * If there are more than two objects create a new type. 
* Implement AnyOf convention: 
  * Find the shared base type and use that type as the parameter type.
  * Generate inline use-case documentation which specify the possible implementations of the parameter. 
* Use open-source model generators if possible;
* Use open-source API generators if possible;
* Support hexagonal architecture;
* Create use-cases and models in domain module;
* Expose use-cases in API adapter module;
* Create best practice Java code;
* Create best practice C# code;
* Support easy code language extension;
* Support easy template overrides;