using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using Newtonsoft.Json;
using protocol.Requests;

namespace apidb
{
    public class UpdateShapeHandler : IHandler
    {
        public PostgresContext DbCtx { get; set; }

        public Task<string> HandleRequest(IRequest req)
        {
            var request = req as IShapeRequest;

            try
            {
                var tmp = DbCtx.dw_shapes.Where(x => x.Id == request.Id).FirstOrDefault();

                if (tmp != null)
                {
                    tmp.ShapeType = (ShapeTypeEnum)request.ShapeType;
                    tmp.UpdateDate = request.UpdateDate;
                    tmp.UpdateAuthor = request.UpdateAuthor;
                    tmp.Color = request.Color;
                    tmp.Coords = request.Coords;

                    DbCtx.SaveChanges();
                }

                var result = JsonConvert.SerializeObject(new StatusResponse() { Status = Status.Success, Description = "ok" });
                return Task.FromResult(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ошибка обновления шейпа: {ex.Message}");
            }
        }
    }
}
