using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using System.Xml.Linq;

namespace apidb
{
    public class CreateDocumentHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public CreateDocumentHandler()
        {            
        }

        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as ICreateDocumentRequest;

            var date = DateTime.Now.ToUniversalTime();

            // id генерится в момент добавления в таблицу            

            var tmp = new dw_document
            {
                Name = request.DocumentName,
                CreateDate = date,
                CreateAuthor = request.UserName
            };

            try
            {
                DbCtx.dw_documents.Add(tmp);
                DbCtx.SaveChanges();

                var doc = DbCtx.dw_documents.Where(x =>
                    x.Name == request.DocumentName &&
                    x.CreateDate == date &&
                    x.CreateAuthor == request.UserName
                ).FirstOrDefault();

                var result = new Document()
                {
                    Header = new DocumentHeader()
                    {
                        Id = doc.Id,
                        Title = doc.Name,
                        UserName = doc.CreateAuthor
                    },
                    Body = new List<Shape>()
                };

                return Task.FromResult(JsonConvert.SerializeObject(result));
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Ошибка создания документа: {ex.Message}");
            }
        }
    }
}
