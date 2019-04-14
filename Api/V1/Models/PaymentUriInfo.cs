namespace CounosPayClient.Api.V1.Models
{
    public class PaymentUriInfo
    {
        public string Address { get; set; }
        public Ticker Ticker { get; set; }
        public string Amount { get; set; }
        public string Extra { get; set; }
    }
}
