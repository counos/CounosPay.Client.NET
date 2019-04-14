using System;
using System.Linq;
using CounosPayClient.Api.V1.Inf;
using CounosPayClient.Api.V1.Models;

namespace CounosPayClient.Api.V1.ExtensionMethods
{
    public static class PaymentUriInfoExtensions
    {
        public static PaymentUriInfo GetPaymentUriInfo_ByUri(this string strUri)
        {
            return string.IsNullOrWhiteSpace(strUri) 
                ? new PaymentUriInfo() 
                : GetPaymentUriInfo_ByUri(new Uri(strUri.Trim()));
        }

        public static PaymentUriInfo GetPaymentUriInfo_ByUri(this Uri uri)
        {
            var qsItems = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var amount = qsItems.AllKeys.Any(x => x.ToLower() == "amount") ? qsItems["amount"] : null;
            var extra = qsItems.AllKeys.Any(x => x.ToLower() == "extra") ? qsItems["extra"] : null;
            var tickerName = uri.Scheme;

            return new PaymentUriInfo
            {
                Address = uri.AbsolutePath,
                Ticker = tickerName.GetTicker_FromTickerName(),
                Amount = amount,
                Extra = extra,
            };
        }

        public static bool IsValid(this PaymentUriInfo paymentUriInfo)
        {
	        if (paymentUriInfo==null ||
	            paymentUriInfo.Ticker == null ||
				!paymentUriInfo.Ticker.IsValid ||
	            string.IsNullOrWhiteSpace(paymentUriInfo?.Address) ||
	            string.IsNullOrWhiteSpace(paymentUriInfo?.Amount)
			)
	        {
		        return false;
	        }

	        return true;
        }
    }
}
