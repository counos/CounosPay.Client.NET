using System;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{

    [Serializable]
    public class GetTerminalTickers_Request : BaseRequest
    {
        public GetTerminalTickers_Request(string terminalId)
        {
            TerminalId = terminalId;
        }

        /// <summary>
        /// Terminal Id
        /// </summary>
        [JsonProperty(PropertyName = "terminal_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalId { get; set; }

    }
}

