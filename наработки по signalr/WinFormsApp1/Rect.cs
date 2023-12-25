using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Draw
{
    class Rect : Shape
    {
        public Rectangle rectangle;
        public Rect(Pen pen) : base(pen)
        {

        }

        public Rect() : base()
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(GetPen, rectangle);
        }

        public override void UpdateShape(Point first, Point second)
        {
            FirstPoint =  first;
            SecondPoint = second;
            rectangle = new Rectangle(
                            Math.Min(first.X, second.X),
                            Math.Min(first.Y, second.Y),
                            Math.Abs(first.X - second.X),
                            Math.Abs(first.Y - second.Y)
                        );
         }
    }
}
