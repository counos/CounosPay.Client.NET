namespace CounosPayClient.Api.V1.Models
{
    public interface IBaseRequest
    {
       //string AccessToken { get; set; }
       // void SetAccessToken(string accessToken);
    }
    public class BaseRequest: IBaseRequest
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "token", NullValueHandling = NullValueHandling.Ignore)]
        //public string AccessToken { get; set; }


        //public void SetAccessToken(string accessToken)
        //{
        //    this.AccessToken = accessToken;
        //}
    }
}
