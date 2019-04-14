using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CounosPayClient.Api.V1.ExtensionMethods;
using CounosPayClient.Api.V1.Models;
using Newtonsoft.Json.Linq;

namespace CounosPayClient.Api.V1.Inf
{
	public static class ApiUtility
	{
		public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}

	    /// <summary>
	    /// This method add one SLASH at the end of the string if it has not SLASH as input
	    /// </summary>
	    /// <param name="path"></param>
	    /// <returns></returns>
	    public static string AppendSlash_IfNotEmpty(this string path)
	    {
	        if (string.IsNullOrEmpty(path))
	        {
	            return path;
	        }
	        return path.TrimEndSlash() + "/";
	    }

        /// <summary>
        /// Append one SLASH at the end of the input string
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
	    public static string TrimEndSlash(this string path)
        {
            return string.IsNullOrEmpty(path) 
                ? path 
                : path.Trim('/');
        }

	    public static Ticker GetTicker_FromTickerShortname(this string tickerShortName)
	    {
	        return Consts.AllTickers.FirstOrDefault(x => x.ShortName?.ToLower() == tickerShortName?.ToLower());
	    }

	    public static Ticker GetTicker_FromTickerName(this string tickerName)
	    {
	        return Consts.AllTickers.FirstOrDefault(x => x.Name?.ToLower() == tickerName?.ToLower());
	    }

	    public static Ticker GetTicker_ByTickerId(this int tickerId)
	    {
	        return Consts.AllTickers.FirstOrDefault(x => x.TickerId == tickerId);
	    }

        public static string GetTitleOfTicker_ByTickerShortname(this string tickerShortName)
	    {
	        return Consts.AllTickers.FirstOrDefault(x => x.ShortName?.ToLower() == tickerShortName?.ToLower())?.Title;
	    }

	    public static string GetShortNameOfTicker(this string tickerTitle)
	    {
	        return Consts.AllTickers.FirstOrDefault(x => x.Title?.ToLower() == tickerTitle?.ToLower())?.ShortName;
	    }

	    public static string GetLongNameOfTicker(this string tickerShortName)
	    {
	        return Consts.AllTickers.FirstOrDefault(x => x.ShortName?.ToLower() == tickerShortName?.ToLower())
	            ?.Name;
	    }

	    public static bool IsPullyPaid(string paymentStatus, decimal expectedAmount, decimal paidAmount, int expectedConfirmations, int reachedConfirmations)
	    {
	        return paymentStatus?.ToLower() == "paid" &&
	               paidAmount >= expectedAmount &&
	               reachedConfirmations >= expectedConfirmations;

	    }

	    public static OrderDetail MakeNewOrderDetail(Guid orderGuid, decimal amount2Deliver_Or_OrderAmount, decimal amount2Exchange_Or_ExpectedAmount,
            Ticker fromTicker, Ticker toTicker, decimal rate, DateTime rateDt,
	        string paymentUri, int expectedConfirmations, DateTime expirePaymentQrAfterDt)
	    {
            return  MakeNewOrderDetail(
                orderGuid.ToString("N"),
                amount2Deliver_Or_OrderAmount,
                amount2Exchange_Or_ExpectedAmount,
                fromTicker,
                toTicker,
	            paymentUri: paymentUri,
                rate: rate,
	            rateDt: rateDt,
	            expectedConfirmations: expectedConfirmations,
	            expirePaymentQrAfterDt: expirePaymentQrAfterDt);
        }

	    public static OrderDetail MakeNewOrderDetail(string orderId,decimal amount2Deliver_Or_OrderAmount, decimal amount2Exchange_Or_ExpectedAmount,
	        Ticker fromTicker, Ticker toTicker, decimal rate, DateTime rateDt,
	        string paymentUri, int expectedConfirmations, DateTime expirePaymentQrAfterDt)
	    {
	        
	        return new OrderDetail
	        {
	            OrderId = orderId,
	            FromTicker = fromTicker,
                OrderAmount = amount2Deliver_Or_OrderAmount,
                ToTicker = toTicker,
	            ExpectedAmount = amount2Exchange_Or_ExpectedAmount,
                    //expectedAmountCalculatedByServer >= 0
                    //? expectedAmountCalculatedByServer
                    //: expectedAmountCalculatedByStore,
                PaidAmount = 0,

	            SpotRateOfTickerVsOrderCurrency = rate,
	            SpotRateOfTickerVsOrderCurrencyDt = rateDt,

	            ExpectedConfirmations = expectedConfirmations,
	            ReachedConfirmations = 0,

	            PaymentStatus = "Waiting to pay",
	            LastUpdatePaymentStatusDt = null,

	            PaymentTrackId =  null, 
	            PaymentUri = paymentUri,

	            PaymentExpireDt = expirePaymentQrAfterDt,// orderCreatedOnUtc.AddMinutes(expirePaymentQrAfterMinutes),
	            CreateDt = DateTime.UtcNow,
	            UpdateDt = DateTime.UtcNow,
        };

	        
	    }

	    public static OrderDetail RefreshOrderDetailByPaymentStatus(this OrderDetail orderDetail,GetPaymentStatus_Response paymentStatus)
	    {
	        var savedT = orderDetail.ToTicker;
	        var newT = paymentStatus.TickerId.GetTicker_ByTickerId();

	        orderDetail.ExpectedAmount = paymentStatus.ExpectedAmount;
	        orderDetail.PaidAmount = paymentStatus.PaidAmount;
	        orderDetail.ExpectedConfirmations = paymentStatus.ExpectedConfirmations;
	        orderDetail.ReachedConfirmations = paymentStatus.ReachedConfirmations;
	        orderDetail.PaymentStatus = paymentStatus.Status;
	        orderDetail.PaymentUri = paymentStatus.PaymentUri;
	        orderDetail.PaymentTrackId = paymentStatus.PaymentTrackId;
	        //orderDetail.ToTicker = newT ?? savedT; // paymentStatus.TickerId.GetTicker_FromTickerId();
	        orderDetail.Transactions = paymentStatus.Transactions;
	        orderDetail.LastUpdatePaymentStatusDt = DateTime.UtcNow;

	        return orderDetail;
	    }


        /// <summary>
        /// https://geeklearning.io/serialize-an-object-to-an-url-encoded-string-in-csharp/
        /// </summary>
        /// <param name="metaToken"></param>
        /// <returns></returns>
	    public static IDictionary<string, string> ToKeyValue(this object metaToken)
	    {
	        if (metaToken == null)
	        {
	            return null;
	        }

	        JToken token = metaToken as JToken;
	        if (token == null)
	        {
	            return ToKeyValue(JObject.FromObject(metaToken));
	        }

	        if (token.HasValues)
	        {
	            var contentData = new Dictionary<string, string>();
	            foreach (var child in token.Children().ToList())
	            {
	                var childContent = child.ToKeyValue();
	                if (childContent != null)
	                {
	                    contentData = contentData.Concat(childContent)
	                        .ToDictionary(k => k.Key, v => v.Value);
	                }
	            }

	            return contentData;
	        }

	        var jValue = token as JValue;
	        if (jValue?.Value == null)
	        {
	            return null;
	        }

	        var value = jValue?.Type == JTokenType.Date ?
	            jValue?.ToString("o", CultureInfo.InvariantCulture) :
	            jValue?.ToString(CultureInfo.InvariantCulture);

	        return new Dictionary<string, string> { { token.Path, value } };
	    }
    }
}
