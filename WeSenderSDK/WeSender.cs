using RestSharp;
using System;
using System.Net.Http;

namespace WeSenderSDK
{
    public class WeSender
    {
        private string url = "http://apiwesender-dev.digitalfactory.co.ao";
        private string apiKey;

        public WeSender (string apiKey)
        {
            this.apiKey = apiKey;
        }

        public void SendMessage(MessageObjectModel messageObject)
        {
            var client = new RestClient(this.url);
            var request = new RestRequest("/envio/apikey", Method.POST);
            request.AddParameter("ApiKey", this.apiKey);
            request.AddParameter("Destino", new String[] {"941056884"});
            request.AddParameter("Mensagem", messageObject.message);
            request.AddParameter("CEspecial", messageObject.hasSpecialCharacter);

            var response = client.Execute(request);
        }
    }
}

