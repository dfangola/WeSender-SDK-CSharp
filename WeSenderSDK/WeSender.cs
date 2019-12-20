using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace WeSenderSDK
{
    public class WeSender
    {
        private string url = "https://api.wesender.co.ao";
        private string apiKey;

        public WeSender (string apiKey)
        {
            this.apiKey = apiKey;
        }

        public WSResult SendMessage(List<string> destines, string message, bool hasSpecialCharacter = false )
        {
            var res = new WSResult {
                Success = false,
                Message = "Generic Erro"
            };

            WebRequest request = WebRequest.Create($"{this.url}/envio/apikey");
            request.Method = "POST";
            request.ContentType = "application/json";

            var body = new
            {
                ApiKey = this.apiKey,
                Destino = destines,
                Mensagem = message,
                CEspecial = hasSpecialCharacter
            };

            var json_order = JsonConvert.SerializeObject(body, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json_order);
            }

            WebResponse response = request.GetResponse();

            var statusCode = Convert.ToInt16(((HttpWebResponse)response).StatusCode);

            if(statusCode == 200)
            {
                string json_string;
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader str = new StreamReader(dataStream);
                    json_string = str.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(json_string))
                {
                    JObject obj = JObject.Parse(json_string);

                    res.Success = (bool)obj["Exito"];

                    res.Message = obj["Mensagem"].ToString();
                }                
            }

            return res;
        }       
        
    }

    public class WSResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}

