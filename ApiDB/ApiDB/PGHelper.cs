using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BDService
{
    public class Payload
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }
    public class PGHelper
    {
        public static void  Process (string json)
        {
            var jobj = JObject.Parse(json);

        }
        public static  bool CreateDoc(string host, string user, string password, string dbname, string port, string json)
        {
            int result = 0;
            var pl = JsonConvert.DeserializeObject<Payload>(json);
            if (pl == null)
                return false;
            string connString = String.Format("Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    host,
                    user,
                    dbname,
                    port,
                    password);
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand("INSERT INTO public.coed_docs(id, title, author, create_dt, update_dt) VALUES (@id, @title, @author, @create_dt, @update_dt)", conn))
                    {
                        command.Parameters.AddWithValue("id", pl.id);
                        command.Parameters.AddWithValue("title", pl.title);
                        command.Parameters.AddWithValue("author", pl.author);
                        command.Parameters.AddWithValue("create_dt", DateTime.Today);
                        command.Parameters.AddWithValue("update_dt", DateTime.Today);
                        result = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result > 0;
        }
       
    }
}
