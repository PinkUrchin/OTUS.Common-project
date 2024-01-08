using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataProvider;

namespace apidb
{
    public interface IHandler
    {
        public Task<string> HandleRequest(IRequest req);
        //public PostgresContext DbCtx { get; set; }
    }
}
