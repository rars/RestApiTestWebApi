namespace RestApiTestWebApi.Controllers

open Microsoft.AspNetCore.Mvc
open Serilog
open RestApiTestDomain.Models
open RestApiTestRepositories

[<ApiController>]
[<Route("api/[controller]")>]
type RestApisController (repository: IRestApisRepository, logger : ILogger) =
    inherit ControllerBase()

    [<HttpGet>]
    member __.Get() : RestApi[] =
        repository.GetRestApis().Result |> Seq.toArray

    [<HttpPost>]
    member __.Post(restApi: RestApi) : RestApi =
        repository.CreateRestApi(restApi).Result
