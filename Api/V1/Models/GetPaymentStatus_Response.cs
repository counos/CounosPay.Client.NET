using System.Collections.Generic;
using CounosPayClient.Api.V1.Inf;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
	public class GetPaymentStatus_Response
	{
		public GetPaymentStatus_Response()
		{
			Transactions=new List<Transaction>();	
		}

        /// <summary>
        /// Use this payment address to generate the payment QR image
        /// </summary>
        [JsonProperty(PropertyName = "payment_uri", NullValueHandling = NullValueHandling.Ignore)]
		public string PaymentUri { get; set; }

		[JsonProperty(PropertyName = "ticker_id", NullValueHandling = NullValueHandling.Ignore)]
		public int TickerId { get; set; }

	    [JsonProperty(PropertyName = "ticker", NullValueHandling = NullValueHandling.Ignore)]
	    public Ticker Ticker => TickerId.GetTicker_ByTickerId();

        [JsonProperty(PropertyName = "payment_track_id", NullValueHandling = NullValueHandling.Ignore)]
		public string PaymentTrackId { get; set; }

		/// <summary>
		/// The url of the page that the user can go there and check the transactions
		/// Usually is the URL of a blockchain include a special address of an account
		/// </summary>
		[JsonProperty(PropertyName = "payment_track_url", NullValueHandling = NullValueHandling.Ignore)]
		public string PaymentTrackUrl { get; set; }

		[JsonProperty(PropertyName = "order_id", NullValueHandling = NullValueHandling.Ignore)]
		public string OrderId { get; set; }

		[JsonProperty(PropertyName = "txs", NullValueHandling = NullValueHandling.Ignore)]
		public List<Transaction> Transactions { get; set; }

	    /// <summary>
	    /// The expected amount to be paid
	    /// </summary>
        [JsonProperty(PropertyName = "expected_amount", NullValueHandling = NullValueHandling.Ignore)]
		public decimal ExpectedAmount { get; set; }

	    /// <summary>
	    /// The paid amount
	    /// </summary>
        [JsonProperty(PropertyName = "paid_amount", NullValueHandling = NullValueHandling.Ignore)]
		public decimal PaidAmount { get; set; }

        /// <summary>
        /// Values:
        ///         » "pending" » Not paid yet
        ///         » "paid" » A payment has been made in this regard, but the amount and conditions with which it is expected should be checked
        /// </summary>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
		public string Status { get; set; }

        /// <summary>
        ///The expected confirmation in the related blockchain
        /// </summary>
        [JsonProperty(PropertyName = "expected_confirmations", NullValueHandling = NullValueHandling.Ignore)]
		public int ExpectedConfirmations { get; set; }

        /// <summary>
        ///The reached confirmations in the related blockchain
        /// </summary>
        [JsonProperty(PropertyName = "reached_confirmations", NullValueHandling = NullValueHandling.Ignore)]
		public int ReachedConfirmations { get; set; }

		

		[JsonIgnore]
		public bool IsPaidFully => ApiUtility.IsPullyPaid(Status, ExpectedAmount, PaidAmount, ExpectedConfirmations, ReachedConfirmations);
	}


	public class Transaction
	{
		[JsonProperty(PropertyName = "hash", NullValueHandling = NullValueHandling.Ignore)]
		public string Hash { get; set; }

		[JsonProperty(PropertyName = "dt", NullValueHandling = NullValueHandling.Ignore)]
		public long Dt { get; set; }

	}
}