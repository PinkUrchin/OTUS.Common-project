using Newtonsoft.Json;
using Protocol.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;
using System.Drawing;
using System.Reflection.Metadata;

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
            var request = req as IShapeRequest;

            var date = DateTime.Now.ToUniversalTime();

            // id генерится в момент добавления в таблицу            

            var tmp = new dw_shape
            {
                DocumentId = request.DocumentId,
                ShapeType = (ShapeTypeEnum)request.ShapeType,
                CreateDate = date,
                UpdateDate = date,
                CreateAuthor = request.CreateAuthor,
                UpdateAuthor = request.UpdateAuthor,
                Color= request.Color,
                Coords = request.Coords
            };

            try
            {
                DbCtx.dw_shapes.Add(tmp);
                DbCtx.SaveChanges();

                var shape = DbCtx.dw_shapes.Where(x=> 
                    x.DocumentId == tmp.DocumentId &&
                    x.ShapeType == tmp.ShapeType && 
                    x.CreateDate == tmp.CreateDate &&
                    x.UpdateDate == tmp.UpdateDate &&
                    x.CreateAuthor == tmp.CreateAuthor// &&
                    //x.UpdateAuthor == tmp.UpdateAuthor &&
                    //x.Color == tmp.Color &&
                    //x.Coords == tmp.Coords
                ).FirstOrDefault();

                var result = new Shape
                {
                    Id = shape.Id,
                    DocumentId = shape.DocumentId,
                    ShapeType = (byte)shape.ShapeType,
                    CreateDate = shape.CreateDate,
                    UpdateDate = shape.UpdateDate,
                    CreateAuthor = shape.CreateAuthor,
                    UpdateAuthor = shape.UpdateAuthor,
                    Color = shape.Color,
                    Coords = shape.Coords
                };

                return Task.FromResult(JsonConvert.SerializeObject(result));
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Ошибка создания шейпа: {ex.Message}");
            }
        }
    }
}
