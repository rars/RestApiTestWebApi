namespace RestApiTestRepositories

open System.Threading.Tasks
open RestApiTestDomain.Models
open RestApiTestRepositories.DatabaseContexts

type IRestApisRepository =
    interface
        abstract member GetRestApis : unit -> RestApi list Task
        abstract member CreateRestApi : RestApi -> Task<RestApi>
    end

type RestApisRepository(context: RestApiTestDataContext) =
    interface IRestApisRepository with
        member this.GetRestApis () =
            let query = async {
                return context.RestApis
                    |> Seq.toList
            }
            Async.StartAsTask(query)
        member this.CreateRestApi entity =
            let query = async {
                context.RestApis.Add(entity) |> ignore
                context.SaveChanges true |> ignore
                return entity
            }
            Async.StartAsTask(query)

type IRestApiTestsRepository =
    interface
        abstract member GetRestApiTests : unit -> RestApiTest list Task
        abstract member CreateRestApiTest : RestApiTest -> Task<RestApiTest>
    end

type RestApiTestsRepository(context: RestApiTestDataContext) =
    interface IRestApiTestsRepository with
        member this.GetRestApiTests() =
            let query = async {
                return context.RestApiTests
                    |> Seq.toList
            }
            Async.StartAsTask(query)
        member this.CreateRestApiTest entity =
            let query = async {
                context.RestApiTests.Add(entity) |> ignore
                context.SaveChanges true |> ignore
                return entity
            }
            Async.StartAsTask(query)
