using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

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
            //var request = req as IGetDocumentByIdRequest;

            //var doc = DbCtx.dw_documents.Where(x => x.Id == request.DocumentId).FirstOrDefault();
            //var shapes = DbCtx.dw_shapes.Where(x => x.Id == request.DocumentId).ToList();

            //var result = new Document
            //{
            //    Header = new DocumentHeader
            //    {
            //        Id = doc.Id,
            //        Title = doc.Name,
            //        UserName = doc.CreateAuthor,
            //        UpdateAuthor = doc.UpdateAuthor,
            //        UpdateDate = doc.UpdateDate != null ? (DateTime)doc.UpdateDate : DateTime.MinValue
            //    },
            //    Body = shapes.Select(x=> new Shape 
            //    { 
                        
                    
            //    }).ToList()
            //};

            //return Task.FromResult(JsonConvert.SerializeObject(result));


            throw new NotImplementedException();
        }
    }
}
