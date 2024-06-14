using StockMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMarket.Data
{
    public class DataStore
    {
        public static List<Stock> Stocks { get; set; } = new List<Stock>
        {
            new Stock
            {
                Id = 1,
                CompanyName = "Reliance Industries Ltd",
                NseSymbol = "RELIANCE",
                StockTypeId = 3,
                MarketPrice = 2500.25,
                TodayLow = 2450.00,
                TodayHigh = 2555.00,
                Week52Low = 2200.00,
                Week52High = 2800.00,
                MarketCap = 500000
            },
            new Stock
            {
                Id = 2,
                CompanyName = "HDFC Bank Ltd",
                NseSymbol = "HDFCBANK",
                StockTypeId = 3,
                MarketPrice = 1800.25,
                TodayLow = 1750.00,
                TodayHigh = 1855.00,
                Week52Low = 1600.00,
                Week52High = 1950.00,
                MarketCap = 400000
            },
            new Stock
            {
                Id = 3,
                CompanyName = "Hindustan Unilever Ltd",
                NseSymbol = "HINDUNILVR",
                StockTypeId = 3,
                MarketPrice = 2300.75,
                TodayLow = 2250.00,
                TodayHigh = 2355.00,
                Week52Low = 2100.00,
                Week52High = 2450.00,
                MarketCap = 200000
            },
            new Stock
            {
                Id = 4,
                CompanyName = "Larsen & Toubro Ltd",
                NseSymbol = "LT",
                StockTypeId = 3,
                MarketPrice = 1600.25,
                TodayLow = 1550.00,
                TodayHigh = 1655.00,
                Week52Low = 1400.00,
                Week52High = 1750.00,
                MarketCap = 300000
            },

            new Stock
            {
                Id = 5,
                CompanyName = "ITC Ltd",
                NseSymbol = "ITC",
                StockTypeId = 2,
                MarketPrice = 220.50,
                TodayLow = 215.00,
                TodayHigh = 225.00,
                Week52Low = 200.00,
                Week52High = 240.00,
                MarketCap = 150000
            },
            new Stock
            {
                Id = 6,
                CompanyName = "Titan Company Ltd",
                NseSymbol = "TITAN",
                StockTypeId = 2,
                MarketPrice = 1800.75,
                TodayLow = 1750.00,
                TodayHigh = 1855.00,
                Week52Low = 1600.00,
                Week52High = 1950.00,
                MarketCap = 200000
            },
            new Stock
            {
                Id = 7,
                CompanyName = "Tata Consumer Products Ltd",
                NseSymbol = "TATACONSUM",
                StockTypeId = 2,
                MarketPrice = 800.25,
                TodayLow = 780.00,
                TodayHigh = 820.00,
                Week52Low = 700.00,
                Week52High = 900.00,
                MarketCap = 100000
            },

            new Stock
            {
                Id = 8,
                CompanyName = "Zomato Ltd",
                NseSymbol = "ZOMATO",
                StockTypeId = 1, 
                MarketPrice = 120.50,
                TodayLow = 115.00,
                TodayHigh = 125.00,
                Week52Low = 100.00,
                Week52High = 135.00,
                MarketCap = 70000
            },
            new Stock
            {
                Id = 9,
                CompanyName = "Tata Power Company Ltd",
                NseSymbol = "TATAPOWER",
                StockTypeId = 1,
                MarketPrice = 120.50,
                TodayLow = 115.00,
                TodayHigh = 125.00,
                Week52Low = 100.00,
                Week52High = 135.00,
                MarketCap = 50000
            }
        };

        public static List<StockType> StockTypes { get; set; } = new List<StockType>
        {
            new StockType { Id = 1, Type = "LargeCap" },
            new StockType { Id = 2, Type = "MidCap" },
            new StockType { Id = 3, Type = "SmallCap" }
        };
    }
}