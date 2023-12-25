using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeSenderSDK
{
    public class WeSender
    {
        private string url = "https://api.wesender.co.ao";
        private string apiKey;
        HttpClient client = new HttpClient();

        public WeSender(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<RequestResult> SendMessage(List<string> messageTarget, string message, bool hasSpecialCharacter = false)
        {
            var sendMessageResponse = new RequestResult
            {
                Success = false,
                Message = "Generic Erro"
            };

            var requestResponse = await client.PostAsJsonAsync<RequestBody>($"{url}/envio/apikey", new RequestBody
            {
                ApiKey = apiKey,
                CEspeciais = hasSpecialCharacter,
                Destino = messageTarget,
                Mensagem = message
            });

            if (requestResponse.IsSuccessStatusCode)
            {
                sendMessageResponse = await requestResponse.Content.ReadFromJsonAsync<RequestResult>();
            }
            else
            {
                sendMessageResponse.Message = (await requestResponse.Content.ReadFromJsonAsync<RequestResult>()).Message;
            }

            return sendMessageResponse;
        }

    }

    public class RequestResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public class RequestBody
    {
        public string ApiKey { get; set; }
        public List<string> Destino { get; set; }
        public string Mensagem { get; set; }
        public bool CEspeciais { get; set; }
    }
}

