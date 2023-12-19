using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public enum Status { Success = 0, DoneWithError, Failure, Begin, Abort};
    public class StatusResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
