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

        public async Task<WSResult> SendMessage(List<string> destines, string message, bool hasSpecialCharacter = false)
        {
            var res = new WSResult
            {
                Success = false,
                Message = "Generic Erro"
            };

            var respostaRequisicao = await client.PostAsJsonAsync<RequestBody>($"{url}/envio/apikey", new RequestBody{
                ApiKey = apiKey,
                CEspeciais = hasSpecialCharacter,
                Destino = destines,
                Mensagem = message
            });

            if(respostaRequisicao.IsSuccessStatusCode){
                res = await respostaRequisicao.Content.ReadFromJsonAsync<WSResult>();
            }else{
                res.Message = (await respostaRequisicao.Content.ReadFromJsonAsync<WSResult>()).Message;
            }

            return res;
        }

    }

    public class WSResult
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

