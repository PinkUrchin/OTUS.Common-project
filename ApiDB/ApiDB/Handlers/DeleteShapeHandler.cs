using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Protocol.Common;
using protocol.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace apidb
{
    public class DeleteShapeHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IDeleteShapeRequest;
            var jobj = JObject.Parse(request?.ShapeInfo);
            var result = JsonConvert.SerializeObject(new StatusResponse() { Status = Status.Success, Description = "ok" });
            return Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
}
