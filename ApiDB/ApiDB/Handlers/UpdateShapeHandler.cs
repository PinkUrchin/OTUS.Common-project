using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace apidb
{
    internal class UpdateShapeHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }

        public Task<string> HandleRequest(IRequest req)
        {
            throw new NotImplementedException();
        }
    }
}
