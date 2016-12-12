// Learn more about F# at http://fsharp.org

open System
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.EntityFrameworkCore
open DotnetTest.DatabaseContext

type Startup() =
    member this.Configure(app:IApplicationBuilder) = 
        let setStandardRoute (routes:IRouteBuilder) =  
                routes.MapRoute(
                    name = "default",
                    template = "{controller}/{action}/{id?}"
                ) |> ignore
        let app = app.UseMvc(fun r -> setStandardRoute r)
        ()

    member this.ConfigureServices(services:IServiceCollection) =
        services.AddMvc() |> ignore
        let connectionString = "Server=(localdb)\\mssqllocaldb;Database=fsharptest;Trusted_Connection=True;MultipleActiveResultSets=true" 
        services.AddDbContext<DatabaseContext>(fun options -> options.UseSqlServer(connectionString)|> ignore) |> ignore
        
        ()

[<EntryPoint>]
let main argv = 
    let host = 
        WebHostBuilder()
            .UseKestrel()
            .UseUrls("http://localhost:5000")
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build()
    host.Run()
    0 // return an integer exit code
