using System;
using CounosPayClient.Api.V1.Inf;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
   public class GetCurrencyRate_Response
    {
        /// <summary>
        /// Fill it with a valid Ticker (Crypto or Currency) short_name
        /// </summary>
        [JsonProperty(PropertyName = "from_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string FromCurrency { get; set; }

        /// <summary>
        /// Fill it with a valid Ticker (Crypto or Currency) short_name
        /// </summary>
        [JsonProperty(PropertyName = "to_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string ToCurrency { get; set; }

        /// <summary>
        /// Rate
        /// </summary>
        [JsonProperty(PropertyName = "rate", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Rate { get; set; }

        /// <summary>
        /// When the relevant rate is received from the market
        /// </summary>
        [JsonProperty(PropertyName = "rate_dt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime RateDt { get; set; }

        


    }
}

