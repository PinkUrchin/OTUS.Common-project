﻿using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace apidb
{    
    public class CreateShapeHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }
        public CreateShapeHandler()
        {
        }
        public Task<string> HandleRequest(IRequest req)
        {
            //var docs = DbCtx.dw_documents.ToList();

            //var result = new DocumentList
            //{
            //    Documents = docs.Select(x => new DocumentHeader()
            //    {
            //        Id = x.Id,
            //        Title = x.Name,
            //        UserName = x.CreateAuthor?.ToString()
            //    }).ToList()
            //};

            //return Task.FromResult(JsonConvert.SerializeObject(result));
            throw new NotImplementedException();
        }
    }
}
