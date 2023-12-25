using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ApiDB.Client
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var req = new Protocol.Common.GetListDocumentsRequest();
            req.UserName = "SemenovaMN";
            await InvokeAsync(JsonConvert.SerializeObject(req));

            System.Console.WriteLine(" Press [enter] to exit.");
            System.Console.ReadLine();
        }

        private static async Task InvokeAsync(string n)
        {
            using var rpcClient = new Client();

            System.Console.WriteLine(" [x] Requesting fib({0})", n);

            var response = await rpcClient.CallAsync(n);
            System.Console.WriteLine(" [.] Got '{0}'", response);
        }
    } 
}
