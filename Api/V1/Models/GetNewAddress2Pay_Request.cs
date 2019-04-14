using System;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
    [Serializable]
    public class GetNewAddress2Pay_Request : BaseRequest
    {
        private int _tickerId;
        private string _terminalId;
        private string _orderId;
        private OrderDetail _orderDetail;
        private string _amount;
        // private string _authSign;
        private int _confirmations;

        public GetNewAddress2Pay_Request(
            // string accessToken,
            int tickerId,
            string storeId,
            string orderId,
            OrderDetail orderDetail,
            string amount,
            int confirmations,
            DateTime paymentExpireDt
            )
        {
            //  _accessToken = _accessToken;
            _tickerId = tickerId;
            _terminalId = storeId;
            _orderId = orderId;
            _orderDetail = orderDetail;
            _amount = amount;
            // _authSign = authSign;
            _confirmations = confirmations < 0 ? 0 : confirmations;
            PaymentExpireDt = paymentExpireDt.ToString("yyyyMMddTHH:mm");
        }

        /// <summary>
        /// Ticker : Coin Short Name
        /// BTC, CCH, CCC,...
        /// </summary>
        [JsonProperty(PropertyName = "ticker_id", NullValueHandling = NullValueHandling.Ignore)]
        public int TickerId
        {
            get => _tickerId;
            private set => _tickerId = value;
        }

        /// <summary>
        /// Terminal Id  (Store Id)
        /// </summary>
        [JsonProperty(PropertyName = "terminal_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalId
        {
            get => _terminalId;
            private set => _terminalId = value;
        }

        /// <summary>
        /// OrderId (will be filled with GUID of the order else Order ID)
        /// </summary>
        [JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId
        {
            get => _orderId;
            private set => _orderId = value;
        }


        /// <summary>
        /// Expected amount to pay (its currency is Ticker)
        /// </summary>
        [JsonProperty(PropertyName = "amount", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpectedAmount
        {
            get => _amount;
            set => _amount = value;
        }

        /// <summary>
        /// The number of expected confirmations
        /// </summary>
        [JsonProperty(PropertyName = "confirmations", NullValueHandling = NullValueHandling.Ignore)]
        public int ExpectedConfirmations
        {
            get => _confirmations;
            set => _confirmations = value;
        }

        /// <summary>
        /// Important details of the order
        /// </summary>
        [JsonIgnore]
        public OrderDetail OrderDetail
        {
            get => _orderDetail;
            private set => _orderDetail = value;
        }

        /// <summary>
        /// The serialized version of OrderDetail
        /// </summary>
        [JsonProperty(PropertyName = "order_detail", NullValueHandling = NullValueHandling.Ignore)]
        public string StrOrderDetail => OrderDetail == null ? string.Empty : JsonConvert.SerializeObject(OrderDetail);

        /// <summary>
        /// Format: ISO 8601    »»   .ToString("yyyyMMddTHH:mm");
        /// </summary>
        [JsonProperty(PropertyName = "payment_expire_dt", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentExpireDt
        {
            get;
            set;
        }

    }
}
