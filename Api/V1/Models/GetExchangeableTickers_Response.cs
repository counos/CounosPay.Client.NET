using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounosPayClient.Api.V1.Inf;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
    //public class GetExchangeableTickers_Response
    //{
    //    public GetExchangeableTickers_Response()
    //    {
    //        Items = new List<ExchangeableTickersItem>();
    //    }

    //    public List<ExchangeableTickersItem> Items { get; set; }
    //}


    public class ExchangeableTickersResponseItem
    {
        [JsonProperty(propertyName: "ticker_id")]
        public int TickerId { get; set; }

        [JsonProperty(propertyName: "ticker")] public Ticker Ticker => TickerId.GetTicker_ByTickerId();

        /// <summary>
        /// Allowed Tickers to exchange with the TickerId
        /// </summary>
        [JsonProperty(propertyName: "allowed")]
        public List<int> Allowed { get; set; }

        /// <summary>
        /// Allowed Tickers to exchange with the TickerId
        /// </summary>
        [JsonProperty(propertyName: "allowed_tickers")]
        public List<Ticker> AllowedTickers
        {
            get { return Allowed.Select(tickerId => tickerId.GetTicker_ByTickerId()).ToList(); }
        }
    }
}
