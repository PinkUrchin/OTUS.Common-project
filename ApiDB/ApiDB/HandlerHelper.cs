using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using protocol.Requests;
using Protocol.Common;
using UfaService.Model;

namespace apidb
{
    public interface IHandler
    {
        Task<string> HandleRequest(IRequest req);
    }
    public class DocumentListHandler: IHandler
    {
        PostgresContext m_dbcontext;
        public DocumentListHandler(PostgresContext dbcontext)
        {
            m_dbcontext = dbcontext;
        }
        public Task<string> HandleRequest(IRequest req)
        {
            //забираем из БД
            //пока загулшка
            var lst1 = m_dbcontext.dw_documents.ToList();
            //var lst = new DocumentList();
            //lst.Documents.Add(new DocumentHeader() { Id = 1, Title = "Document 1", UserName = "SemenovaMN" });
            //lst.Documents.Add(new DocumentHeader() { Id = 2, Title = "Document 2", UserName = "SemenovaMN" });
            //lst.Documents.Add(new DocumentHeader() { Id = 3, Title = "Document 3", UserName = "SemenovaMN" });
            return Task.FromResult(JsonConvert.SerializeObject(lst1));
        }
    }
    public class CreateDocumentHandler : IHandler
    {
        PostgresContext m_dbcontext;
        public CreateDocumentHandler(PostgresContext dbcontext)
        {
            m_dbcontext = dbcontext;
        }
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as ICreateDocumentRequest;
            //пока загулшка
            var result = new Document()
            {
                Header = new DocumentHeader() { Id = 1, Title = request.DocumentName, UserName = request.UserName },
                Body = new List<Primitive>()
            };
            return Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
    public class DeleteDocumentHandler : IHandler
    {
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IDeleteDocumentByIdRequest;
            var result = JsonConvert.SerializeObject(new StatusResponse() { Status = Status.Success, Description = "ok" });
            return Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
    public class DeleteFigureHandler : IHandler
    {
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IDeleteFigureRequest;
            var jobj = JObject.Parse(request?.FigureInfo);
            var result = JsonConvert.SerializeObject(new StatusResponse() { Status = Status.Success, Description = "ok" });
            return Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
    public class GetDocumentByIdRequestHandler : IHandler
    {
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IGetDocumentByIdRequest;
            var result = JsonConvert.SerializeObject(new Document()
            {
                Header = new DocumentHeader() { Id = request.DocumentId },
                Body = new List<Primitive>() }) ;
            return Task.FromResult(JsonConvert.SerializeObject(result));
        }
    }
    public class RequestHandler
    {
        private PostgresContext m_dbcontext = new PostgresContext();
        private readonly Dictionary<string, IHandler> m_handlers;

        public RequestHandler()
        {
            m_handlers = new Dictionary<string, IHandler>
            {
                {Actions.GetListDocuments, new DocumentListHandler(m_dbcontext) },
                {Actions.DeleteDocumentById, new DeleteDocumentHandler() },
                {Actions.CreateDocument, new CreateDocumentHandler(m_dbcontext) },
                {Actions.DeleteFigure, new DeleteFigureHandler() }

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
