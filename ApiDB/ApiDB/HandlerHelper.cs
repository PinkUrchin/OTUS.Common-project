using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Protocol.Common;

namespace apidb
{
    public interface IHandler
    {
        Task<string> HandleRequest(IRequest req);
    }
    public class DocumentListHandler: IHandler
    {
        public Task<string> HandleRequest(IRequest req)
        {
            //забираем из БД
            //пока загулшка
            var lst = new DocumentList();
            lst.Documents.Add(new DocumentHeader() { Id = 1, Title = "Document 1", UserName = "SemenovaMN" });
            lst.Documents.Add(new DocumentHeader() { Id = 2, Title = "Document 2", UserName = "SemenovaMN" });
            lst.Documents.Add(new DocumentHeader() { Id = 3, Title = "Document 3", UserName = "SemenovaMN" });
            return Task.FromResult(JsonConvert.SerializeObject(lst));
        }
    }
    public class RequestHandler
    {

        private readonly Dictionary<string, IHandler> m_handlers;

        public RequestHandler()
        {
            m_handlers = new Dictionary<string, IHandler>
            {
                {Actions.GetListDocuments, new DocumentListHandler() }
            };

        }

        public async Task<string> HandleRequest(string req)
        {
            var request = Request.ReadRequest(req);
            if (request == null)
                return "";
            if (!m_handlers.TryGetValue(request.Action, out var handler))
                return "";
            try
            {
                return await handler.HandleRequest(request);
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
