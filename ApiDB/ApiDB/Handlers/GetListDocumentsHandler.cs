using Microsoft.EntityFrameworkCore;
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
    public class GetListDocumentsHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public GetListDocumentsHandler()
        {            
        }
        public Task<string> HandleRequest(IRequest req)
        {
            try
            {
                var docs = DbCtx.dw_documents.ToList();

                var result = new DocumentList
                {
                    Documents = docs.Select(x => new DocumentHeader()
                    {
                        Id = x.Id,
                        Title = x.Name,
                        UserName = string.IsNullOrEmpty(x.CreateAuthor) ? string.Empty : x.CreateAuthor.ToString()
                    }).ToList()
                };

                return Task.FromResult(JsonConvert.SerializeObject(result));
            }
            catch(Exception ex)
            {
                throw new Exception($"Ошибка получения списка документов: {ex.Message}");
            }
        }
    }
}
