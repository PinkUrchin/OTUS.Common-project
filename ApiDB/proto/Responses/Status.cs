using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol.Common
{
    public enum Status { Success = 0, DoneWithError, Failure, Begin, Abort};

    public interface IStatusResponse : IResponse
    {
        [JsonProperty("status")]
        Status Status { get; set; }
        [JsonProperty("description")]
        string Description { get; set; }
    }

    public class StatusResponse: BaseResponse, IStatusResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        public StatusResponse() : base(ResponseName.Status) { }
    }
}
