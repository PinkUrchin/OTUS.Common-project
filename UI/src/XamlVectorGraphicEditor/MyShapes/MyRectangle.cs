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

class MyRectangle : AbstractShape
{
    public MyRectangle(in Point p) : base(p, new Rectangle() { Fill = Brushes.LightBlue }) 
    { }
    
    public override object Clone()
    {
        var p = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
        var ret = new MyRectangle(p);
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
        return new MyRectangleDTO(this);
    }

    public override Protocol.Common.Shape CreateProtocolShape()
    {
        var ret = base.CreateProtocolShape();
        ret.ShapeType = (byte)ShapeType.Rectangle;
        return ret;
    }
}
