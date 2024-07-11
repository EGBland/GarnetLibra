module GarnetLibra.Core.Provider.DataProvider

open GarnetLibra.Core.Error;
open GarnetLibra.Core.Model
open GarnetLibra.Core.Provider.Util;

type IDataProvider =
    interface
        abstract GetWorldByName: name: string -> Result<World option, GarnetLibraError>
        abstract GetItemByName: name: string -> Result<Item option, GarnetLibraError>
    end

type UnionDataProvider (providers: IDataProvider list) =
    class   
        member private this.Providers with get () = providers : IDataProvider list
        
        member private this.ProvideFirst (func: IDataProvider -> Result<'T, GarnetLibraError>): Result<'T, GarnetLibraError> =
            ProvideFirst this.Providers func
        
        interface IDataProvider with
            member this.GetWorldByName (name: string): Result<World option, GarnetLibraError> =
                this.ProvideFirst (fun provider -> provider.GetWorldByName name)
            
            member this.GetItemByName (name: string): Result<Item option, GarnetLibraError> =
                this.ProvideFirst (fun provider -> provider.GetItemByName name)
    end