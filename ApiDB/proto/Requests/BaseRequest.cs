using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public interface IRequest
    {
        [JsonProperty("Action")]
        public string Action { get; set; }
    }
    public class Request : IRequest
    {
        [JsonProperty("Action")]
        public string Action { get; set; }
        public Request(string action_name)
        {
            Action = action_name;
        }
        public static IRequest ReadRequest(string data)
        {
            return JsonConvert.DeserializeObject<IRequest>(data, new RequestConverter());
        }
    }
}
