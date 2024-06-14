using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockMarket.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string NseSymbol { get; set; }
        public int StockTypeId { get; set; }
        public double MarketPrice { get; set; }
        public double TodayLow { get; set; }
        public double TodayHigh { get; set; }
        public double Week52Low { get; set; }
        public double Week52High { get; set; }
        public double MarketCap { get; set; }
    }
}