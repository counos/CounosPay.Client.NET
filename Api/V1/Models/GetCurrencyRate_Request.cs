using System;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{

    [Serializable]
    public class GetCurrencyRate_Request : BaseRequest
    {
        public GetCurrencyRate_Request(string fromCurrency, string toCurrency)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
        }

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

    }
}

