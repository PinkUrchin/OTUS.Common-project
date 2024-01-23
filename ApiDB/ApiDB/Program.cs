
using System;
using System.Text;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System.Threading.Tasks;
using System.IO;
using apidb;

namespace BDService
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine(Environment.GetEnvironmentVariable("RbName"));
            //Console.WriteLine(Environment.GetEnvironmentVariable("RbServer"));
            //Console.WriteLine(Environment.GetEnvironmentVariable("RbLogin"));
            //Console.WriteLine(Environment.GetEnvironmentVariable("RbPassword"));

            yeqon.Settings settings = new yeqon.Settings
            {
                Name = "doc_db",
                Queue = "doc_db",
                Server = "85.193.81.154",
                Login = "guest",
                Password = "guest",
                NoAck = false,
                Durable = true
            };
            var handler = new RequestHandler();
            var listener = new yeqon.Listener();
            listener.Init(settings);
            listener.OnMessage += (data, id, reply_to) =>
            {
                var json = Encoding.UTF8.GetString(data);
                var worker = new Task(async () =>
                {
                    var res = await handler.HandleRequest(json);
                    if (string.IsNullOrEmpty(res)) {
                        res = "error";
                    }
                    listener.Reply(id, reply_to, Encoding.UTF8.GetBytes(res));
                });
                worker.Start();
            };
            await listener.Run();
        }


    }
}
