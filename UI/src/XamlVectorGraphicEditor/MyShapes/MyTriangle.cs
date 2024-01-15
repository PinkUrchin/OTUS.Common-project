using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using XamlVectorGraphicEditor.MyShapes;
using XamlVectorGraphicEditor.MyShapesDTO;

class MyTriangle : AbstractShape
{
    public MyTriangle(in Point p) : base(p, new Polygon()
    {
        Points = new PointCollection()
        {
            new Point(0, 1),
            new Point(1, 0),
            new Point(2, 1)
        },
        Fill = Brushes.LightPink,
        Stretch = Stretch.Fill
    })
    { }

    public override object Clone()
    {
        var p = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
        var ret = new MyTriangle(p);
        ret.Height = Height;
        ret.Width = Width;
        ret.RenderTransform = RenderTransform;
        ret.LayoutTransform = LayoutTransform;
        ret.BorderBrush = BorderBrush;

        var otherShape = Child as Shape;
        Shape newShape = ret.Child as Shape;
        newShape.Fill = otherShape.Fill;
        newShape.RenderTransform = otherShape.RenderTransform;
        newShape.LayoutTransform = otherShape.LayoutTransform;
        
        return ret;
    }

    public override AbstractShapeDTO CreateDTO()
    {
        return new MyTriangleDTO(this);
    }

    public override Protocol.Common.Shape CreateProtocolShape()
    {
        var ret = base.CreateProtocolShape();
        ret.ShapeType = (byte)ShapeType.Triangle;
        return ret;
    }
}

