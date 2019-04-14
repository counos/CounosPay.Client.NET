using System;
using System.IO;
using System.Linq;
using CounosPayClient.Api.V1.Inf;

namespace CounosPayClient.Api.V1
{
    public class Client
    {
        public string Host { get; set; } = "pg.api.counos.org";

        public Int32 Port { get; set; } = 80;

        public string Path { get; set; } = "";

        public string ApiVersion { get; set; } = "v1";

        public Boolean Secure { get; set; } = false;
        
        public Client(bool withHttps = false)
        {
            this.Secure = withHttps;
        }

        public void SetServerAddress(bool ssl, string host, int port, string path, string apiVersion)
        {
            Secure = ssl;
            Host = host;
            Port = port;
            Path = path;
            ApiVersion = apiVersion;
        }


        public string ApiUrl => HttpProtocol() + "://"
                                               + Host.TrimEndSlash()
                                               + (Port > 0 && Port != 80 ? $":{Port}" : "") + "/"
                                               + Path.AppendSlash_IfNotEmpty()
                                               + ApiVersion.AppendSlash_IfNotEmpty();


        public string HttpProtocol()
        {
            return Secure ? "https" : "http";
        }

    }
}