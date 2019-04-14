using System;
using System.Collections.Generic;
using CounosPayClient.Api.V1.Inf;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
	[Serializable]
	public class OrderDetail
	{
		public OrderDetail()
		{
			Transactions=new List<Transaction>();
		}

	    private int _expectedConfirmations;
	    private int _reachedConfirmations;
		//private double _spotRateOfTickerVsOrderCurrencyTimestamp;

		/// <summary>
	    /// Guid of Order in nopCommerce
	    /// </summary>
	    [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
	    public string OrderId { get; set; }
		
		[JsonProperty("payment_track_id", NullValueHandling = NullValueHandling.Ignore)]
		public string PaymentTrackId { get; set; }

		[JsonProperty("payment_track_url", NullValueHandling = NullValueHandling.Ignore)]
		public string PaymentTrackUrl { get; set; }

		
	    /// <summary>
	    /// CCH, BTC, ...
	    /// </summary>
	    [JsonProperty("to_ticker", NullValueHandling = NullValueHandling.Ignore)]
	    public Ticker ToTicker { get; set; }

	    /// <summary>
        /// Expected amount to pay as Ticker
        /// </summary>
		[JsonProperty("expected_amount", NullValueHandling = NullValueHandling.Ignore)]
		public decimal ExpectedAmount { get; set; }

	    [JsonProperty("paid_amount", NullValueHandling = NullValueHandling.Ignore)]
	    public decimal PaidAmount { get; set; }

        
	    [JsonProperty("from_ticker", NullValueHandling = NullValueHandling.Ignore)]
        public Ticker FromTicker { get; set; }

        /// <summary>
        /// Price of order in unit of OrderCurrency
        /// </summary>
	    [JsonProperty("order_amount", NullValueHandling = NullValueHandling.Ignore)]
	    public decimal OrderAmount { get; set; }
        
	    /// <summary>
	    /// For example: 
	    /// </summary>
	    [JsonProperty("payment_uri", NullValueHandling = NullValueHandling.Ignore)]
	    public string PaymentUri { get; set; }

       /// <summary>
        /// Spot Rate of Ticker against OrderCurrency
        /// </summary>
        [JsonProperty("spot_rate_of_ticker_vs_Order_currency", NullValueHandling = NullValueHandling.Ignore)]
		public decimal SpotRateOfTickerVsOrderCurrency { get; set; }

		/// <summary>
	    /// Timestamp of » Spot Rate of Ticker against OrderCurrency
	    /// </summary>
	    [JsonProperty("spot_rate_of_ticker_vs_order_currency_dt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime SpotRateOfTickerVsOrderCurrencyDt { get; set; }

		/// <summary>
		/// Number of Expected Confirmations
		/// </summary>
		[JsonProperty("expected_confirmations", NullValueHandling = NullValueHandling.Ignore)]
	    public int ExpectedConfirmations
	    {
	        get => _expectedConfirmations;
	        set => _expectedConfirmations = value < 0 ? 0 : value;
	    }

	    /// <summary>
	    /// Number of reached Confirmations until last Check-Payment-Status
	    /// </summary>
	    [JsonProperty("reached_confirmations", NullValueHandling = NullValueHandling.Ignore)]
	    public int ReachedConfirmations
	    {
	        get => _reachedConfirmations;
	        set => _reachedConfirmations = value < 0 ? 0 : value;
	    }

        /// <summary>
        /// Expire time to pay
        /// </summary>
	    [JsonProperty("payment_expire_dt", NullValueHandling = NullValueHandling.Ignore)]
	    public DateTime PaymentExpireDt { get; set; }

		/// <summary>
		/// Payment function is expired and the customers should create a new order
		/// </summary>
		[JsonIgnore]
		public bool PaymentIsExpired => DateTime.UtcNow > PaymentExpireDt;

		//
		[JsonProperty("create_dt", NullValueHandling = NullValueHandling.Ignore)]
	    public DateTime CreateDt { get; set; }

	    [JsonProperty("update_dt", NullValueHandling = NullValueHandling.Ignore)]
	    public DateTime UpdateDt { get; set; }

	    [JsonProperty("payment_status", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentStatus { get; set; }

	    [JsonProperty("txs", NullValueHandling = NullValueHandling.Ignore)]
	    public List<Transaction> Transactions { get; set; }

		/// <summary>
		/// The date-time of the last payment status request
		/// </summary>
		[JsonProperty("last_update_payment_status_dt", NullValueHandling = NullValueHandling.Ignore)]
		public DateTime? LastUpdatePaymentStatusDt { get; set; }

		[JsonIgnore]
		public bool IsPaidFully => ApiUtility.IsPullyPaid(PaymentStatus, ExpectedAmount,PaidAmount,ExpectedConfirmations,ReachedConfirmations);


	}
}