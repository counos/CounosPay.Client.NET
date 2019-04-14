using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
    public class GetPaymentStatus_Request : BaseRequest
    {
        private string _terminalId;
        private string _orderId;

        public GetPaymentStatus_Request(
            string terminalId,
            string orderId)
        {
            _terminalId = terminalId;
            _orderId = orderId;
        }

        /// <summary>
        /// Terminal ID = Client ID
        /// </summary>
        [JsonProperty(PropertyName = "terminal_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalId
        {
            get => _terminalId;
            private set => _terminalId = value;
        }

        /// <summary>
        /// Maybe it is better to fill this field with the Order GUID of the saved order in your store 
        /// </summary>
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId
        {
            get => _orderId;
            private set => _orderId = value;
        }

        
    }

}
