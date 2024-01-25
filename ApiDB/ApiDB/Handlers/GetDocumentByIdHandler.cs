using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using Newtonsoft.Json;

namespace apidb
{
    public class GetDocumentByIdHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public GetDocumentByIdHandler()
        {
        }
        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IGetDocumentByIdRequest;

            try
            {
                var doc = DbCtx.dw_documents.Where(x => x.Id == request.DocumentId).FirstOrDefault();
                var shapes = DbCtx.dw_shapes.Where(x => x.DocumentId == request.DocumentId).ToList();

                var result = new Document
                {
                    Header = new DocumentHeader
                    {
                        Id = doc.Id,
                        Title = doc.Name,
                        UserName = doc.CreateAuthor,
                        UpdateAuthor = doc.UpdateAuthor,
                        UpdateDate = doc.UpdateDate != null ? (DateTime)doc.UpdateDate : DateTime.MinValue
                    },
                    Body = shapes.Select(x => new Shape
                    {
                        Id = x.Id,
                        ShapeType = (byte)x.ShapeType,
                        CreateDate = x.CreateDate,
                        UpdateDate = x.UpdateDate,
                        CreateAuthor = x.CreateAuthor,                        
                        DocumentId = x.Id,
                        Coords = x.Coords
                    }).ToList()
                };

                return Task.FromResult(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex) 
            {
                throw new ArgumentException($"Ошибка получения документа по id: {ex.Message}");
            }
        }
    }
}
