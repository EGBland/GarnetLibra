module GarnetLibra.Core.Model

type DataCentreRegion =
    | Europe
    | NorthAmerica
    | Japan
    | Oceania
    | Korea

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

type MarketBoardListing =
    {
        World         : World
        Item          : Item
        Price         : int
        Quantity      : int
        IsHighQuality : bool
        Retainer      : Retainer
    }