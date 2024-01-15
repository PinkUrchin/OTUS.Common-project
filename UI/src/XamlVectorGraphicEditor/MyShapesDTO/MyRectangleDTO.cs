﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlVectorGraphicEditor.MyShapesDTO
{
    internal class MyRectangleDTO : AbstractShapeDTO
    {
        
        public System.Windows.Point Point { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public System.Windows.Media.Color FillColor { get; set; }

        /// <summary>
        /// Create random Rectangle
        /// </summary>
        public MyRectangleDTO()
        {
            Point = new System.Windows.Point(_random.Next(1000), _random.Next(1000));
            Width = _random.Next(100, 200);
            Height = _random.Next(100, 200);
            FillColor = RandomColor();
        }

        public MyRectangleDTO(MyRectangle rect)
        {
            Point = rect.Point;
            Width = rect.Width;
            Height = rect.Height;
            FillColor = rect.FillColor;
        }

        public MyRectangle CreateRectangle(string userName)
        {
            var ret = new MyRectangle(Point);
            ret.Width = Width;
            ret.Height = Height;
            ret.FillColor = FillColor;
            ret.UserName = userName;

            return ret;
        }
    }
}
