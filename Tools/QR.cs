using System.Web;

namespace CounosPayClient.Tools
{
    // ReSharper disable once InconsistentNaming
    public static class QR
    {
        // ReSharper disable once InconsistentNaming
        public static string Get_QR_Url(this string paymentUrl)
        {
            //Google QR Generator URL:
            return $"https://chart.googleapis.com/chart?chs=250x250&cht=qr&chl={HttpUtility.UrlEncode(paymentUrl)}";
        }
    }
}
