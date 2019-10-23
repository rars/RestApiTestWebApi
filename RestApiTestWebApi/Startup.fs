namespace RestApiTestWebApi

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.EntityFrameworkCore;
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Serilog
open Autofac
open AutofacSerilogIntegration
open RestApiTestRepositories
open RestApiTestRepositories.DatabaseContexts

type Startup private () =
    new (configuration: IConfiguration) as this =
        Startup() then
        this.Configuration <- configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services
            .AddControllers()
            .AddNewtonsoftJson() |> ignore

        services.AddOpenApiDocument() |> ignore

        services.AddScoped<IRestApisRepository, RestApisRepository>() |> ignore
        services.AddScoped<IRestApiTestsRepository, RestApiTestsRepository>() |> ignore

        // TODO: make db file location configurable
        services.AddDbContext<RestApiTestDataContext>(fun optionsBuilder ->
            optionsBuilder.UseSqlite("Data Source=testing-framework.db", fun o -> o.MigrationsAssembly("DatabaseMigrations") |> ignore) |> ignore) |> ignore

    member this.ConfigureContainer(builder: ContainerBuilder) =
        builder.RegisterLogger() |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseHttpsRedirection() |> ignore
        app.UseRouting() |> ignore

        app.UseAuthorization() |> ignore
        app.UseSerilogRequestLogging() |> ignore

        app.UseOpenApi() |> ignore
        app.UseSwaggerUi3() |> ignore

        app.UseEndpoints(fun endpoints ->
            endpoints.MapControllers() |> ignore
            ) |> ignore

    member val Configuration : IConfiguration = null with get, set
