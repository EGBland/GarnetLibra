module internal GarnetLibra.Core.Provider.Util

open GarnetLibra.Core.Error

let ProvideFirst (providers: 'T list) (func: 'T -> Result<'U, GarnetLibraError>): Result<'U, GarnetLibraError> =
    // TODO check eagerness of map evaluation
    // TODO propagation of errors (if an earlier provider fails for reasons other than NoProvider, should we continue or return that error?)
    match
        providers
        |> List.map func
        |> List.skipWhile Result.isError
        |> List.tryHead
    with
    | Some r -> r
    | None -> Error(GarnetLibraError.NoProvider)