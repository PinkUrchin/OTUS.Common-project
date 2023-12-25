using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Draw
{
    class Line : Shape
    {
        public Line(Pen pen) : base(pen)
        {

        }

        public Line() : base()
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(GetPen, FirstPoint, SecondPoint);
        }

        public override void UpdateShape(Point start, Point end)
        {
            FirstPoint = start;
            SecondPoint = end;
        }
    }
}
