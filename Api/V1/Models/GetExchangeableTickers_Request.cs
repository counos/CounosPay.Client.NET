using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
    public class GetExchangeableTickers_Request : BaseRequest
    {
        public GetExchangeableTickers_Request()
        {
            TickerIds = new List<int>();
        }

        public GetExchangeableTickers_Request(IEnumerable<int> tickerIds)
        {
            TickerIds = (List<int>) (tickerIds?.Any() ?? false ? tickerIds : new List<int>());
        }

        public GetExchangeableTickers_Request(int tickerId)
        {
            TickerIds = new List<int>() { tickerId };
        }

        [JsonProperty(propertyName: "ticker_ids")]
        public List<int> TickerIds { get; private set; }
    }
}
