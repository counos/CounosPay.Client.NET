using System;
using CounosPayClient.Api.V1.Models;

namespace CounosPayClient.Api.V1.Exceptions
{
	public class CounosPayException : Exception
	{
		public CounosPayException(BaseResponse resp,string respSerialized)
		{
			ResponseBody = resp;
		    SerializedResponse = respSerialized;
        }

	    public string SerializedResponse { get; set; }

	    public BaseResponse ResponseBody { get; set; }
	}

	public class CounosPay_TokenException : CounosPayException
	{
		public CounosPay_TokenException(BaseResponse resp, string respSerialized) : base(resp, respSerialized)
		{
		}
	}

    public class CounosPay_OtherException : CounosPayException
    {
        public CounosPay_OtherException(BaseResponse resp, string respSerialized) : base(resp, respSerialized)
        {
        }
    }

    public class CounosPay_IncorrectUrlException : CounosPayException
    {
        public CounosPay_IncorrectUrlException(string respSerialized) : base(null, respSerialized)
        {
            
        }
    }

    public class CounosPay_ConnectionRefused : CounosPayException
    {
        public CounosPay_ConnectionRefused(BaseResponse resp, string respSerialized) : base(resp, respSerialized)
        {
        }
    }

    
}
