module GarnetLibra.Core.Model

type DataCentreRegion =
    | Europe
    | NorthAmerica
    | Japan
    | Oceania
    | Korea

type Item =
    {
        Id   : int
        Name : string
    }

type Retainer =
    {
        Id   : string
        Name : string
    }

type World =
    {
        Id         : int
        Name       : string
        DataCentre : DataCentre
    }

and DataCentre =
    {
        Id     : int
        Name   : string
        Region : DataCentreRegion
        Worlds : World list
    }

type MarketBoardListing =
    {
        World         : World
        Item          : Item
        Price         : int
        Quantity      : int
        IsHighQuality : bool
        Retainer      : Retainer
    }