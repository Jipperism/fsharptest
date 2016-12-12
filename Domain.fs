namespace DotnetTest.Domain

open System
open Microsoft.EntityFrameworkCore
open System.ComponentModel.DataAnnotations

type AlternateEntity () = 
    [<Key>]
    member val Id = 0 with get, set