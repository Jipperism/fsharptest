namespace Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Routing

type TestController() =
    inherit Controller()

    [<HttpGet>]
    member this.Test() =
        "TestSuccesfull!"