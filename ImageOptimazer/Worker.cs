using System;
using System.Collections.Generic;
using Kraken;
using Kraken.Http;
using System.Net;
using Kraken.Model;

namespace ImageOptimizer
{
    class Worker
    {
        private readonly string _key;
        private readonly string _secret;
        private readonly string _filePath;
        public string KrakenURL { get; set; }
        public string ErrorMessage { get; set; }
        public static Dictionary<string, string> Parameter { get; set; }


        public Worker(string key, string secret, string filePath)
        {
            _key = key;
            _secret = secret;
            _filePath = filePath;
        }

        public Worker(string key, string secret, string filePath, Dictionary<string, string> param)
            :this(key, secret, filePath)
        {
            if (param != null)
            {
                Parameter = param;
            }
        }


        // send image file to kraken.io API for further optimization
        public void SendImage()
        {
            bool isLossy = (Parameter != null) && Convert.ToBoolean(Parameter["Lossy"]);
            var connection = Connection.Create(_key, _secret);
            var client = new Client(connection);
            var response = client.OptimizeWait(_filePath, new OptimizeUploadWaitRequest { Lossy = isLossy });

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                KrakenURL = (string)response.Result.Body.KrakedUrl;
            }
            else
            {
                ErrorMessage = (string)response.Result.Error;
            }
        }

        // load optimized image file
        public void LoadImage()
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(new Uri(KrakenURL), _filePath + ".back");
                }
            }
            catch (WebException e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}

    
