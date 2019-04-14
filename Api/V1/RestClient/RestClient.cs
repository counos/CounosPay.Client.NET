using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CounosPayClient.Api.V1.Inf;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.RestClient
{
    // Http Verbs used to call Rest API
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }
    //To call Rest API
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public object DataToSend { get; set; }
        public string CallType { get; set; }
        public string AccessToken { get; set; }
        //private ErrorManager _errLog = new ErrorManager("File");

        public RestClient()
        {

        }
       
        public RestClient(string endpoint, HttpVerb method, object jsonData, string callType, string accessToken)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            CallType = callType;
            DataToSend = jsonData;
            AccessToken = accessToken;
        }

        public async Task<SendRequestAnswer> SendRequestBaseAsync()
        {
            return await SendRequestBaseAsync(string.Empty);
        }

      
        // Sends request to CounosPay API and returns data in Json format.
        public async Task<SendRequestAnswer> SendRequestBaseAsync(string parameters)
        {
            var answer=new SendRequestAnswer();
	        //webException = null;
         //   responseValue = null;

            //------------------------------ If is GET and we have JsonData-------------------------------
            var queryString="";
            if (DataToSend != null && Method == HttpVerb.GET)
            {
                // json 2 queryString
                //var jObj = (JObject)JsonConvert.DeserializeObject(DataToSend);

                //queryString = string.Join("&",
                //    jObj.Children().Cast<JProperty>()
                //        .Select(jp => jp.Name + (jp.Type== JTokenType.Array?"[]":"")+ "=" + HttpUtility.UrlEncode(jp.Value.ToString())));

                var keyValueContent = DataToSend.ToKeyValue();
                var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);
                queryString = await formUrlEncodedContent.ReadAsStringAsync();
            }
            //-----------------------------------------------------------------------------------------
            
            var request = (HttpWebRequest) WebRequest.Create(
                EndPoint + CallType + parameters
                + (string.IsNullOrEmpty(queryString) ? "" :"?"+ queryString));

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
          
            if (DataToSend != null && Method == HttpVerb.POST || Method == HttpVerb.PATCH)
            {
                if (!string.IsNullOrEmpty(AccessToken))
                    request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AccessToken);
                //var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(JsonConvert.SerializeObject(DataToSend));
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            if (!string.IsNullOrEmpty(AccessToken))
            {
                request.Headers.Remove(HttpRequestHeader.Authorization);
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + AccessToken);
            }

	        try
	        {
		        using (var response = (HttpWebResponse) request.GetResponse())
		        {
			        if ((response.StatusCode != HttpStatusCode.OK) &&
			            (response.StatusCode != HttpStatusCode.Created) &&
			            (response.StatusCode != HttpStatusCode.NoContent) &&
			            (response.StatusCode != HttpStatusCode.Accepted))
			        {
				        var message = $"Request failed. Received HTTP {response.StatusCode}";
				        throw new ApplicationException(message);
			        }

			        // grab the response
			        using (var responseStream = response.GetResponseStream())
			        {
				        if (responseStream != null)
					        using (var reader = new StreamReader(responseStream))
					        {
					            answer.ResponseValue = reader.ReadToEnd();
					        }
			        }
			        answer.Result=true;
		            return answer;
		        }
	        }
	        catch (WebException ex)
	        {
	            answer.WebException = ex;
	            answer.ResponseValue = $"{ex.Message}";
	        }
	        catch (Exception ex)
	        {
	            answer.ResponseValue = $"{ex.Message}";
			}

            answer.Result = false;
            return answer;
        }



        public class SendRequestAnswer
        {
            public bool Result { get; set; }
            public string ResponseValue { get; set; }

            public WebException WebException { get; set; }
        }
    }
}