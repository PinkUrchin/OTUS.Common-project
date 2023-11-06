
using System;
using System.Text;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using System.Threading.Tasks;
using System.IO;

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
                Server = "127.0.0.1",
                Login = "debug",
                Password = "debug",
                NoAck = false,
                Durable = true
            };

            var listener = new yeqon.Listener();
            listener.Init(settings);
            listener.OnMessage += (data, id, reply_to) =>
            {
                var worker = new Task(async () =>
                {
                    var resp = "";
                    listener.Reply(id, reply_to, Encoding.UTF8.GetBytes(resp));
                });
                worker.Start();
            };
            await listener.Run();
        }

        
    }
}
