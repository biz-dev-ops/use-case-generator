# OpenAPI use-case exposer

OpenAPI schemas reference the use-case schemas so that a relationship is created between the OpenAPI action and a use-case. [The generated mapping file](../use-case-generator/README.md#mapping) is used to map adapter types to the generated domain types.

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

1. Throw error if one or more use-case parameters are missing in the OpenAPI action schema.
2. Create OpenAPI action interface implementation which executes the use-case if the use-case parameters exactly match the OpenAPI action parameters.
3. Create abstract OpenAPI action interface implementation which executes the use-case surrounded with pre and post abstract methods if there are more OpenAPI action parameters than use-case parameters.
