module GarnetLibra.Core.Http

open System.Net.Http

type RestHandler (baseUrl: string) =
    member private this.BaseUrl with get () = baseUrl: string
    
    member private this.ResolvePath (path: string): string =
        // TODO sanitise
        this.BaseUrl + path
    
    member public this.Get (path: string): string =
        let tsk = task {
            use client = new HttpClient ()
            let fullPath = this.ResolvePath path
            return! client.GetStringAsync fullPath
        }
        ""
        