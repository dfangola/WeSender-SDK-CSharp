using System;
using System.Collections.Generic;
using WeSenderSDK;

namespace TestSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            var WSDK = new WeSender("589682376d834134b0be4b163a699ffb7d1d64d433544b35b9a53ce2b787413a");
            var list = new List<string>();
            list.Add("941056884");
            var payload = new MessageObjectModel();
            payload.destine = list;
            payload.message = "Olá";

            WSDK.SendMessage(payload);
        }
    }
}
