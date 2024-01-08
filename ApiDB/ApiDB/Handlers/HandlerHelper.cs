using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using protocol.Requests;
using Protocol.Common;
using DataProvider;

namespace apidb
{
    public class RequestHandler
    {        
        private readonly Dictionary<string, IHandler> m_handlers;

        public RequestHandler()
        {
            var postgresContext = new PostgresContext();

            m_handlers = new Dictionary<string, IHandler>
            {
                { Actions.GetListDocuments, new GetListDocumentsHandler { DbCtx = postgresContext} },
                { Actions.CreateShape, new CreateShapeHandler { DbCtx = postgresContext} },
                { Actions.DeleteDocumentById, new DeleteDocumentHandler { DbCtx = postgresContext} },
                { Actions.GetDocumentById, new GetDocumentByIdHandler { DbCtx = postgresContext} },
                { Actions.DeleteShape, new DeleteShapeHandler { DbCtx = postgresContext} },
                { Actions.UpdateShape, new UpdateShapeHandler { DbCtx = postgresContext} },
                { Actions.CreateDocument, new CreateDocumentHandler(postgresContext) }
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
