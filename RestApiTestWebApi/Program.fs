namespace RestApiTestWebApi

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Serilog
open Serilog.Events
open Autofac.Extensions.DependencyInjection

module Program =
    let exitCode = 0

    let CreateHostBuilder args =
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(fun webBuilder ->
                webBuilder.UseStartup<Startup>()
                    .UseSerilog() |> ignore
            )

    let CreateLogger () =
        Log.Logger <- LoggerConfiguration()
            .Destructure.FSharpTypes()
            .Enrich.FromLogContext()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .WriteTo.Console()
            .CreateLogger()

    [<EntryPoint>]
    let main args =
        CreateLogger()

        CreateHostBuilder(args).Build().Run()

        exitCode
