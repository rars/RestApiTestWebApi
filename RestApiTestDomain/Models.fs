namespace RestApiTestDomain.Models

// TODO: add auto-generated unique identifier
type [<CLIMutable>] RestApi = { Name: string; BaseUrl: string }

// TODO: link RestApiTests to RestApis
type [<CLIMutable>] RestApiTest = { RestApiTestId: int64; RequestPath: string; RequestBody: string; ExpectedResponseStatusCode: int32; ExectedResponseJsonSchema: string }
