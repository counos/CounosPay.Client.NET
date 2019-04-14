using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using CounosPayClient.Api.V1.Exceptions;
using CounosPayClient.Api.V1.Models;
using CounosPayClient.Api.V1.RestClient;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CounosPayClient.Api.V1
{
    public class Api
    {
        public Client Client { get; private set; }
	    
		public string AccessToken { get; private set; }

        public Api(string accessToken, bool withHttps)
        {
            AccessToken = accessToken;
            Client = new Client(withHttps);
        }

	    public void SetServerAddress(bool ssl, string host, int port, string path, string apiVersion)
	    {
		    Client.SetServerAddress(ssl, host, port, path, apiVersion);
	    }


		public async Task<GetCurrencyRate_Response> GetCurrencyRateAsync(GetCurrencyRate_Request reqModel)
        {
            return await SendRequest<GetCurrencyRate_Response>(EndPoints.GetCurrencyRate, reqModel, HttpVerb.POST) as GetCurrencyRate_Response;
        }

        public async Task<GetNewAddress2Pay_Response> GetNewAddress2PayAsync(GetNewAddress2Pay_Request reqModel)
        {
            return await SendRequest<GetNewAddress2Pay_Response>(EndPoints.GetNewAddressToPay, reqModel, HttpVerb.POST) as GetNewAddress2Pay_Response;
        }

        public async Task<GetPaymentStatus_Response> GetPaymentStatusAsync(GetPaymentStatus_Request reqModel)
        {
            return await SendRequest<GetPaymentStatus_Response>(EndPoints.GetPaymentStatus, reqModel, HttpVerb.POST) as GetPaymentStatus_Response;
        }

        public async Task<GetTerminalTickers_Response> GetTerminalTickersAsync(GetTerminalTickers_Request reqModel)
        {
            return await SendRequest<GetTerminalTickers_Response>(EndPoints.GetTerminalTickers, reqModel, HttpVerb.POST) as GetTerminalTickers_Response;
        }

        public Task<List<ExchangeableTickersResponseItem>> GetExchangeableTickersAsync(GetExchangeableTickers_Request reqModel)
        {
            return SendRequest<List<ExchangeableTickersResponseItem>>(EndPoints.GetExchangeableTickers, reqModel,HttpVerb.GET);
        }

        private async Task<T> SendRequest<T>(string endPoint, IBaseRequest reqModel, HttpVerb httpVerb)
        {
         
            var endpointUrl = Client.ApiUrl + endPoint?.Trim('/')+"/";
            //var jsonData = JsonConvert.SerializeObject(reqModel, Formatting.None);

            var rest = new RestClient.RestClient(
                endpointUrl
                , httpVerb
                , reqModel
                , ""
                , AccessToken);

            var answer = await rest.SendRequestBaseAsync();
            if (!answer.Result)
            {
	            var respBody = string.Empty;
                if (answer.WebException == null)
                {
                    throw new Exception("CounosPay Error! WebException is null");
                }
                if (answer.WebException != null && answer.WebException.Response == null)
                {
                    throw new CounosPay_ConnectionRefused(null, answer.WebException.Message);
                }
	            var respStream = answer.WebException.Response.GetResponseStream();
	            BaseResponse resp=null;
                string respSerialized = null;
                if (respStream != null)
	            {
		            respSerialized = new StreamReader(respStream).ReadToEnd();
	                try
	                {
	                    resp = JsonConvert.DeserializeObject<BaseResponse>(respSerialized);
                    }
	                catch (Exception e)
	                {
	                    throw new CounosPay_IncorrectUrlException(respSerialized);
                    }
	            }
				if (answer.ResponseValue?.Contains("403") ?? false)
	            {
		            throw new CounosPay_TokenException(resp, respSerialized);
	            }
				else
	            {
					throw new CounosPay_OtherException(resp, respSerialized);
				}
            }
            var objData = JsonConvert.DeserializeObject<BaseResponse>(answer.ResponseValue).Data;
            var objResp = JsonConvert.DeserializeObject<T>(objData.ToString());
            return objResp;
        }


        public string CreateJwtToken(string jsonPayload, string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk")
        {
            var obj = JsonConvert.DeserializeObject(jsonPayload);
            var payload = obj.GetType().GetProperties().ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(obj));
            return CreateJwtToken(payload);
        }
        
       
        public string CreateJwtToken(Dictionary<string, object> payloadItems, string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk")
        {

            var builder = new JwtBuilder()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(secret)
                ;

            foreach (var item in payloadItems)
            {
                builder.AddClaim(item.Key, item.Value);
            }

            var token = builder.Build();
            return token;
        }

        public string VerifyAndGetPayload_OfJwtToken(string token, string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk")
        {
            string json;
            try
            {
                json = new JwtBuilder()
                    .WithSecret(secret)
                    .MustVerifySignature()
                    .Decode(token);
            }
            catch (InvalidTokenPartsException e)
            {
                throw new Exception("Invalid Token!",e);
            }
            catch (TokenExpiredException e)
            {
                throw new Exception("Token has expired", e);
            }
            catch (SignatureVerificationException e)
            {
                throw new Exception("Token has invalid signature", e);
            }

            return json;
        }


    }


}
