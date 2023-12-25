using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace Draw
{

    class PenSettings
    {

        public byte r { get; set; } = 0;
        public byte g { get; set; } = 0;
        public byte b { get; set; } = 0;
        public float width { get; set; } = 0;

        public PenSettings()
        {
        }
    }

    enum Shapes
    {
        Line = 1,
        Rect,
        Circle,
        Free
    }

    abstract class Shape
    {
        public Point FirstPoint { get; set; }

        public Point SecondPoint { get; set; }


        public PenSettings PenSettings = new PenSettings();

        protected Pen GetPen => new Pen(Color.FromArgb(255, PenSettings.r, PenSettings.g, PenSettings.b), PenSettings.width) {StartCap = System.Drawing.Drawing2D.LineCap.Round, EndCap = System.Drawing.Drawing2D.LineCap.Round };

        public Shape(Pen pen)
        {
            PenSettings.r = pen.Color.R;
            PenSettings.g = pen.Color.G;
            PenSettings.b = pen.Color.B;
            PenSettings.width = pen.Width;
        }

        public Shape() { }

        public abstract void Draw(Graphics g);
        public abstract void UpdateShape(Point start, Point end);
    }
}
