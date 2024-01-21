using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XamlVectorGraphicEditor;
using XamlVectorGraphicEditor.MyShapesDTO;

abstract partial class AbstractShape : Border, ICloneable
{
    private static AbstractShape Top;
    private static int LastZIndex;
    private double CurrentRotate = 0;

    private void RectMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (Top != null)
        {
            Top.BorderBrush = Brushes.Black;
            Top.BorderThickness = new Thickness(0.2);
        }
        Top = this;
        Canvas.SetZIndex(this, ++LastZIndex);
        CaptureMouse();
        BorderThickness = new Thickness(2);
        BorderBrush = Brushes.Red;
    }

    private void RectMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();
        BorderBrush = Brushes.DeepSkyBlue;
    }

    private async void DeleteClick(object sender, RoutedEventArgs e)
    {
        bool canDelete = true;

        var shape = GetProtocolShape();
        if (shape != null)
        {
            var result = await Context.DataProvider().DeleteShapeAsync(shape, Context.UserName);
            canDelete = result.Status == Protocol.Common.Status.Success;

            if (canDelete)
            {
                Context.Document.Body.RemoveAll(x => x.Id == shape.Id);
            }
        }

        if (canDelete)
            (VisualParent as Canvas).Children.Remove(this);
    }

    private void Rotate(in int angle)
    {
        CurrentRotate += angle;
        if (CurrentRotate >= 360)
        {
            CurrentRotate -= 360;
        }
        var shape = Child as Shape;

        var rotate = new RotateTransform(CurrentRotate, Height / 2, Width / 2);
        if (shape is Rectangle && (CurrentRotate % 90) == 0)
        {
            var h = Height;
            Height = Width;
            Width = h;
        }
        shape.LayoutTransform = rotate;
    }

    private void Right10Click(object sender, RoutedEventArgs e) => Rotate(10);

    private void Right30Click(object sender, RoutedEventArgs e) => Rotate(30);

    private void Right60Click(object sender, RoutedEventArgs e) => Rotate(60);

    private void Right90Click(object sender, RoutedEventArgs e) => Rotate(90);

    private void CloneClick(object sender, RoutedEventArgs e) =>
        (VisualParent as Canvas).Children.Add(Copy());

    public AbstractShape(in Point whereSetMe, in Shape shape)
    {
        InitializeComponent();
        Child = shape;
        ContextMenu.AddPaletteHeader(new ShapeBackgroundChanger(shape, () => Changed?.Invoke(this)));
        Canvas.SetLeft(this, whereSetMe.X);
        Canvas.SetTop(this, whereSetMe.Y);
        LastZIndex = Canvas.GetZIndex(this);
    }

    public Action<AbstractShape> Changed { get; set; }

    public AbstractShape Copy()
    {
        var ret = Clone() as AbstractShape;

        var p = ret.Point;
        ret.Point = new Point(p.X + 15, p.Y + 15);

        return ret;
    }

    public int Id { get; set; }

    public Protocol.Common.Shape GetProtocolShape()
    {
        var shape = Context.Document.Body.Find(x => x.Id == Id);
        return shape;   
    }
    
    public string UserName { get; set; }
    public Color FillColor
    {
        get
        {
            if ((Child as Shape).Fill is SolidColorBrush sb)
                return sb.Color;
            else
                return Color.FromArgb(0, 0, 0, 0);
        }
        set
        {
            (Child as Shape).Fill = new SolidColorBrush(value);
        }
    }

    public Point Point {
        get => new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
        set
        {
            Canvas.SetLeft(this, value.X);
            Canvas.SetTop(this, value.Y);
        }
    }

    public abstract object Clone();
    public abstract AbstractShapeDTO CreateDTO();

    public virtual Protocol.Common.Shape CreateProtocolShape()
    {
        var ret = new Protocol.Common.Shape();
        ret.CreateDate = DateTime.Now;
        ret.UpdateDate = ret.CreateDate;
        ret.CreateAuthor = Context.UserName;
        ret.UpdateAuthor = ret.CreateAuthor;
        ret.DocumentId = Context.Document.Header.Id;
        ret.Coords = JsonConvert.SerializeObject(CreateDTO());
        return ret;
    }    
}

