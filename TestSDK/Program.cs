using System;
using System.Collections.Generic;
using WeSenderSDK;

namespace TestSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            var WSDK = new WeSender("apikey");
            var list = new List<string>();
            list.Add("920000000");
            var payload = new MessageObjectModel();
            payload.destine = list;
            payload.message = "Olá";

            WSDK.SendMessage(payload);
        }
    }
}
