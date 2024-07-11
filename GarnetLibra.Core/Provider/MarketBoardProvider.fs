module GarnetLibra.Core.Provider.MarketBoardProvider

open GarnetLibra.Core.Error
open GarnetLibra.Core.Model
open GarnetLibra.Core.Provider.Util

type IMarketBoardProvider =
    interface
        abstract GetListings: world: World -> item: Item -> Result<MarketBoardListing list, GarnetLibraError>
    end

type UnionMarketBoardProvider (providers: IMarketBoardProvider list) =
    class
        member private this.Providers with get () = providers: IMarketBoardProvider list
        
        member private this.ProvideFirst (func: IMarketBoardProvider -> Result<'T, GarnetLibraError>): Result<'T, GarnetLibraError> =
            ProvideFirst this.Providers func
        
        interface IMarketBoardProvider with
            member this.GetListings (world: World) (item: Item) =
                this.ProvideFirst (fun provider -> provider.GetListings world item)
    end