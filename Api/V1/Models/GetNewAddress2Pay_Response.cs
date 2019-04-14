using System;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
    [Serializable]
    public class GetNewAddress2Pay_Response {
       // private string _tickerName;
        private int _tickerId;
        private string _orderId;
        //private string _authSign;
        private string _paymentUri;

	    public GetNewAddress2Pay_Response()
	    {
		    
	    }

	    //public GetNewAddress2Pay_Response(string tickerName,string orderId,string paymentUri)
	    //{
		   // TickerName = tickerName;
		   // OrderId = orderId;
		   // PaymentUri = paymentUri;
	    //}

        public GetNewAddress2Pay_Response(Ticker ticker, string orderId, string paymentUri)
        {
            //TickerName = ticker.Name;
            OrderId = orderId;
            PaymentUri = paymentUri;
        }

  //      /// <summary>
		///// Ticker : Coin Short Name
		///// BTC, CCH, CCC,...
		///// </summary>
		//[JsonProperty(PropertyName = "ticker_name", NullValueHandling = NullValueHandling.Ignore)]
  //      public string TickerName
  //      {
  //          get => _tickerName;
		//	private set => _tickerName = value;
  //      }

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
        /// Ticker : Coin Short Name
        /// BTC, CCH, CCC,...
        /// </summary>
        [JsonProperty(PropertyName = "payment_uri", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentUri
        {
            get => _paymentUri;
            private set => _paymentUri = value;
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
        
        public bool IsValid => !string.IsNullOrWhiteSpace(PaymentUri);

    }
}
