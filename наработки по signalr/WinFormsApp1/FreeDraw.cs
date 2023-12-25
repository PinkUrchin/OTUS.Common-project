
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    class FreeDraw : Shape
    {
        public List<Point>  points = new List<Point>();

        public FreeDraw() : base()
        {

        }

        public FreeDraw(Pen pen) : base(pen)
        {
            points = new List<Point>();
        }

        public override void Draw(Graphics graphics)
        {

            if (!points.Any()) return;
            
            var parr = points.ToArray();

            for (int i = 0; i < parr.Length-1; i++)
            {
                graphics.DrawLine(GetPen, parr[i].X,parr[i].Y, parr[i+1].X, parr[i+1].Y);
            }
            
        }

        public override void UpdateShape(Point start, Point end)
        {
            FirstPoint = start;
            SecondPoint = end;
            points.Add(end);
        }
    }
}
