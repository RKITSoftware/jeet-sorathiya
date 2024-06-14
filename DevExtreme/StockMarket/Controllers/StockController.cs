using StockMarket.Data;
using StockMarket.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Linq.Dynamic;

namespace StockMarket.Controllers
{
    public class DevExtremeFilter
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }

    public class DevExtremeSort
    {
        public string Selector { get; set; }
        public bool Desc { get; set; }
    }
    public class StockController : ApiController
    {
        [HttpGet, Route("Stocks")]
        public IHttpActionResult GetStocks(int skip = 0, int take = 3, string sort = null, string filter = null)
        {
            var stocks = DataStore.Stocks.AsQueryable();

            // Apply filtering
            if (!string.IsNullOrEmpty(filter))
            {
                // Parsing the filter
                var filters = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DevExtremeFilter>>(filter);
                foreach (var f in filters)
                {
                    stocks = stocks.Where($"{f.Field}.Contains(@0)", f.Value);
                }
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(sort))
            {
                var sorts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DevExtremeSort>>(sort);
                foreach (var s in sorts)
                {
                    stocks = stocks.OrderBy($"{s.Selector} {(s.Desc ? "desc" : "asc")}");
                }
            }

            //  Apply paging

            var totalCount = stocks.Count();
            stocks = stocks.Skip(skip).Take(take);

            var result = new
            {
                data = stocks.ToList(),
                totalCount
            };
            return Ok(result);
        }

        [HttpGet, Route("Stocks/{id:int}")]
        public IHttpActionResult GetStock(int id)
        {
            var stock = DataStore.Stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

        [HttpPost, Route("Stocks")]
        public IHttpActionResult CreateStock([FromBody] Stock stock)
        {
            if (stock == null)
            {
                return BadRequest("Stock cannot be null");
            }

            stock.Id = DataStore.Stocks.Max(s => s.Id) + 1;
            DataStore.Stocks.Add(stock);
            return Ok();
        }

        [HttpPut, Route("Stocks/{id:int}")]
        public IHttpActionResult UpdateStock(int id, [FromBody] Stock stock)
        {
            var existingStock = DataStore.Stocks.FirstOrDefault(s => s.Id == id);
            if (existingStock != null)
            {
                // Merge existing stock with the new values
                existingStock.CompanyName = stock.CompanyName ?? existingStock.CompanyName;
                existingStock.NseSymbol = stock.NseSymbol ?? existingStock.NseSymbol;
                existingStock.StockTypeId = stock.StockTypeId != 0 ? stock.StockTypeId : existingStock.StockTypeId;
                existingStock.MarketPrice = stock.MarketPrice != 0 ? stock.MarketPrice : existingStock.MarketPrice;
                existingStock.TodayLow = stock.TodayLow != 0 ? stock.TodayLow : existingStock.TodayLow;
                existingStock.TodayHigh = stock.TodayHigh != 0 ? stock.TodayHigh : existingStock.TodayHigh;
                existingStock.Week52Low = stock.Week52Low != 0 ? stock.Week52Low : existingStock.Week52Low;
                existingStock.Week52High = stock.Week52High != 0 ? stock.Week52High : existingStock.Week52High;
                existingStock.MarketCap = stock.MarketCap != 0 ? stock.MarketCap : existingStock.MarketCap;
            }
            return Ok(existingStock);
        }

        [HttpDelete, Route("Stocks/{id:int}")]
        public IHttpActionResult DeleteStock(int id)
        {
            var stock = DataStore.Stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            DataStore.Stocks.Remove(stock);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpGet, Route("types")]
        public IHttpActionResult GetStockTypes()
        {
            return Ok(DataStore.StockTypes);
        }

        [HttpGet, Route("types/{id:int}")]
        public IHttpActionResult GetStockType(int id)
        {
            var stockType = DataStore.StockTypes.FirstOrDefault(s => s.Id == id);
            if (stockType == null)
            {
                return NotFound();
            }
            return Ok(stockType);
        }
    }
}
