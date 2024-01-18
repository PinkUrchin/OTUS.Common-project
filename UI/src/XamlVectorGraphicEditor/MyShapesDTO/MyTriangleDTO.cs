using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlVectorGraphicEditor.MyShapesDTO
{
    internal class MyTriangleDTO : AbstractShapeDTO
    {

        public System.Windows.Point Point { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public System.Windows.Media.Color FillColor { get; set; }

        /// <summary>
        /// Create random Triangle
        /// </summary>
        public MyTriangleDTO()
        {
            Point = new System.Windows.Point(_random.Next(1000), _random.Next(1000));
            Width = _random.Next(100, 200);
            Height = _random.Next(100, 200);
            FillColor = RandomColor();
        }

        public MyTriangleDTO(MyTriangle triangle)
        {
            Point = triangle.Point;
            Width = triangle.Width;
            Height = triangle.Height;
            FillColor = triangle.FillColor;
        }

        public MyTriangle CreateTriangle(string userName)
        {
            var ret = new MyTriangle(Point);
            ret.Width = Width;
            ret.Height = Height;
            ret.FillColor = FillColor;
            ret.UserName = userName;

            return ret;
        }
    }
}
