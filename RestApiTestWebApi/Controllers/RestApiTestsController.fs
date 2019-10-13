namespace RestApiTestWebApi.Controllers

open Microsoft.AspNetCore.Mvc
open Serilog
open RestApiTestDomain.Models
open RestApiTestRepositories

[<ApiController>]
[<Route("api/[controller]")>]
type RestApiTestsController (repository: IRestApiTestsRepository, logger : ILogger) =
    inherit ControllerBase()

    [<HttpGet>]
    member __.Get() : RestApiTest[] =
        repository.GetRestApiTests().Result |> Seq.toArray

    [<HttpPost>]
    member __.Post(restApi: RestApiTest) : RestApiTest =
        repository.CreateRestApiTest(restApi).Result
