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
            var destines = new List<string>();
            destines.Add("920000000");
            
            string message = "Olá";

            WSDK.SendMessage(destines, message);
        }
    }
}
