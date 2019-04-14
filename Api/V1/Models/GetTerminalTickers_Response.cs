using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
   public class GetTerminalTickers_Response
    {
        public GetTerminalTickers_Response()
        {
            TickerIds=new int[]{};
        }

        public GetTerminalTickers_Response(int[] tickers)
        {
            TickerIds = new int[] { };
        }
        /// <summary>
        /// The list of Ticker Ids that the owner of the store has defined the related merchant accounts for ech one in the dashboard of th CounosPay website
        /// </summary>
        [JsonProperty(PropertyName = "ticker_ids", NullValueHandling = NullValueHandling.Ignore)]
        public int[] TickerIds { get; set; }

    }
}

