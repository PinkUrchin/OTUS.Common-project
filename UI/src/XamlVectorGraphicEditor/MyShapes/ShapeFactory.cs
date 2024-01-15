using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using XamlVectorGraphicEditor.MyShapesDTO;

namespace XamlVectorGraphicEditor.MyShapes
{
    public enum ShapeType
    {
        Rectangle = 0,
        Ellipse = 1,
        Triangle = 2
    }

    internal class ShapeFactory
    {
        private static Dictionary<ShapeType, Func<AbstractShapeDTO>> _createDTOMethod = new Dictionary<ShapeType, Func<AbstractShapeDTO>>();
        private static Dictionary<ShapeType, Func<Protocol.Common.Shape, UIElement>> _createShape = new Dictionary<ShapeType, Func<Protocol.Common.Shape, UIElement>>();

        static ShapeFactory()
        {
            _createDTOMethod.Add(ShapeType.Rectangle, () => new MyRectangleDTO());
            _createDTOMethod.Add(ShapeType.Ellipse, () => new MyEllipseDTO());
            _createDTOMethod.Add(ShapeType.Triangle, () => new MyTriangleDTO());

            _createShape.Add(ShapeType.Rectangle, shape =>
            {
                var dto = JsonConvert.DeserializeObject<MyRectangleDTO>(shape.Coords);
                return dto.CreateRectangle(Context.UserName);
            });

            _createShape.Add(ShapeType.Ellipse, shape =>
            {
                var dto = JsonConvert.DeserializeObject<MyEllipseDTO>(shape.Coords);
                return dto.CreateEllipse(Context.UserName);
            });

            _createShape.Add(ShapeType.Triangle, shape =>
            {
                var dto = JsonConvert.DeserializeObject<MyTriangleDTO>(shape.Coords);
                return dto.CreateTriangle(Context.UserName);
            });
        }

        public static AbstractShapeDTO CreateShapeDTO(ShapeType shapeType)
        {
            if (_createDTOMethod.TryGetValue(shapeType, out var result))
                return result.Invoke();

            return null;
        }

        public static UIElement CreateShape(Protocol.Common.Shape shape)
        {
            if (_createShape.TryGetValue((ShapeType)shape.ShapeType, out var build))
            {
                var ret = build(shape);
                if (ret is AbstractShape abstractShape)
                {
                    abstractShape.Id = shape.Id;
                    abstractShape.UserName = shape.UpdateAuthor;
                }

                return ret;
            }

            return null;
        }
    }
}
