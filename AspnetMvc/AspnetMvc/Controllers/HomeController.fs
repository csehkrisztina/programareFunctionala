namespace AspnetMvc.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Web
open System.Web.Mvc
open System.Web.Mvc.Ajax

[<CLIMutable>]
type NameModel = {name:string}

type HomeController() =
    inherit Controller()

    [<HttpGet>]
    member this.Index () = this.View()

    [<HttpPost>]
    member this.Index (model:NameModel) = 
        //sprintf "Hello %s" model.name 
        this.View(box model.name)

