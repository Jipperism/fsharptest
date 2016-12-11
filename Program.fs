// Learn more about F# at http://fsharp.org

open System
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection

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
        let services = services.AddMvc()
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
