using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace XamlVectorGraphicEditor.MyShapesDTO
{
    internal class MyEllipseDTO : AbstractShapeDTO
    {
        public System.Windows.Point Point { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public System.Windows.Media.Color FillColor { get; set; }

        /// <summary>
        /// Create random Ellipse
        /// </summary>
        public MyEllipseDTO()
        {
            Point = new System.Windows.Point(_random.Next(1000), _random.Next(1000));
            Width = _random.Next(100, 200);
            Height = _random.Next(100, 200);
            FillColor = RandomColor();
        }

        public MyEllipseDTO(MyEllipse ellipse) 
        {
            Point = ellipse.Point;
            Width = ellipse.Width;
            Height = ellipse.Height;
            FillColor = ellipse.FillColor;
        }

        public MyEllipse CreateEllipse(string userName)
        {
            var ret = new MyEllipse(Point);
            ret.Width = Width;
            ret.Height = Height;
            ret.FillColor = FillColor;
            ret.UserName = userName;

            return ret;
        }
    }
}
