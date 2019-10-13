namespace RestApiTestRepositories.DatabaseContexts

open Microsoft.EntityFrameworkCore
open RestApiTestDomain.Models

type RestApiTestDataContext(options : DbContextOptions<RestApiTestDataContext>) =
    inherit DbContext(options)

    [<DefaultValue>]
    val mutable _restApis : DbSet<RestApi>

    member x.RestApis
        with get() = x._restApis
        and set v = x._restApis <- v

    [<DefaultValue>]
    val mutable _restApiTests : DbSet<RestApiTest>

    member x.RestApiTests
        with get() = x._restApiTests
        and set v = x._restApiTests <- v

    override x.OnModelCreating(modelBuilder: ModelBuilder) =
        modelBuilder.Entity<RestApi>().HasKey("Name") |> ignore
        modelBuilder.Entity<RestApiTest>().HasKey("RestApiTestId") |> ignore
