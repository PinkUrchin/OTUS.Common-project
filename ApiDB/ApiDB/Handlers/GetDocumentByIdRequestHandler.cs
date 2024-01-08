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
    public class GetDocumentByIdRequestHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IGetDocumentByIdRequest;
            var result = JsonConvert.SerializeObject(new Document()
            {
                Header = new DocumentHeader() { Id = request.DocumentId },
                Body = new List<Shape>()
            });
            return Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
}
