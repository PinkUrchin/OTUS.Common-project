using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace apidb
{
    public class DeleteDocumentHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IDeleteDocumentByIdRequest;
            var result = JsonConvert.SerializeObject(new StatusResponse() { Status = Status.Success, Description = "ok" });
            return Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
}
