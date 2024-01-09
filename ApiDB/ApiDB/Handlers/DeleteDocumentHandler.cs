using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using Microsoft.EntityFrameworkCore;

namespace apidb
{
    public class DeleteDocumentHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IDeleteDocumentByIdRequest;

            try
            {
                var tmp_shapes = DbCtx.dw_shapes.Where(x => x.DocumentId == request.DocumentId).ToList();

                if (tmp_shapes?.Any() ?? false)
                {
                    DbCtx.dw_shapes.RemoveRange(tmp_shapes);
                    DbCtx.SaveChanges();
                }

                var tmp_doc = DbCtx.dw_documents.Where(x => x.Id == request.DocumentId).FirstOrDefault();

                if (tmp_doc != null)
                {
                    DbCtx.dw_documents.Remove(tmp_doc);
                    DbCtx.SaveChanges();
                }

                var result = JsonConvert.SerializeObject(new StatusResponse() { Status = Status.Success, Description = "ok" });
                return Task.FromResult(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка удаления документа: {ex.Message}");
            }
        }
    }
}
