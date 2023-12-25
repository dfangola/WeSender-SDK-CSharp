using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeSenderSDK;

namespace TestSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            (EnviarMensagem()).GetAwaiter().GetResult();
        }

        static async Task EnviarMensagem()
        {
            var WSDK = new WeSender("e09b3146403c40b1b9db47867e29fd4422e3761bdaa5468b8f514d79e4a641e3");
            var destines = new List<string>();
            destines.Add("920000000");

            string message = "Olá";

            var resultado = await WSDK.SendMessage(destines, message);
            Console.WriteLine(resultado.Message);
        }
    }
}
