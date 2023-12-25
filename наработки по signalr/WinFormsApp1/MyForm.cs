using Draw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MySignalR;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Draw
{
    public partial class Form1 : Form
    {

        HubConnection connection;  // подключение для взаимодействия с хабом

        private Point? startPoint;
        private Point? endPoint;
        private Point previous;
        private bool isDrawing;
        private Pen pen;
        private Graphics graphics;
        private Shapes currentShapeType = Shapes.Free;
        private Shape curShape;
        Stack<Shape> shapes = new Stack<Shape>();
        Stack<Shape> undoshapes = new Stack<Shape>();
        List<Shape> otherusersShapes = new List<Shape>();
        Bitmap bmp = new Bitmap(100, 100);

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 2);
            graphics = CreateGraphics();


            var rectang = pictureBox1.Bounds;

            bmp = new Bitmap(rectang.Width, rectang.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            isDrawing = false;

            SetSignalRConnection();
        }



        void SetSignalRConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://85.193.81.154:5007/chat")
                .Build();


            connection.StartAsync();

            connection.On<string, string>("ReceiveLine", (user, shapeJson) =>
            {
                Line line = JsonConvert.DeserializeObject<Line>(shapeJson);
                otherusersShapes.Add(line);
                pictureBox1.Invalidate();
            });

            connection.On<string, string>("ReceiveCircle", (user, shapeJson) =>
            {
                Circle line = JsonConvert.DeserializeObject<Circle>(shapeJson);
                otherusersShapes.Add(line);
                pictureBox1.Invalidate();
            });

            connection.On<string, string>("ReceiveRectangle", (user, shapeJson) =>
            {
                Rect rectangle = JsonConvert.DeserializeObject<Rect>(shapeJson);
                otherusersShapes.Add(rectangle);
                pictureBox1.Invalidate();
            });

            connection.On<string, string>("ReceiveFree", (user, shapeJson) =>
            {
                FreeDraw fd = JsonConvert.DeserializeObject<FreeDraw>(shapeJson);
                otherusersShapes.Add(fd);
                pictureBox1.Invalidate();
            });

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            isDrawing = true;
            endPoint = null;
            previous = new Point(e.X, e.Y);
            curShape = ObjectShape(currentShapeType);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            if (endPoint != null)
            {
                shapes.Push(curShape);
                startPoint = null;
                undoshapes.Clear();
                sendCurShape();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            graphics = e.Graphics;

            if (isDrawing)
            {
                curShape.Draw(graphics);
                //sendCurShape();
            }

            foreach (Shape item in shapes)
            {
                item.Draw(graphics);
            }

            foreach (Shape item in otherusersShapes)
            {
                item.Draw(graphics);
            }
        }

        private async void sendCurShape()
        {
            string senName = "";
            switch (currentShapeType)
            {
                case Shapes.Circle:
                    {
                        senName = "SendCircle";
                        break;
                    }
                case Shapes.Rect:
                    {
                        senName = "SendRectangle";
                        break;
                    }
                case Shapes.Line:
                    {
                        senName = "SendLine";
                        break;
                    }
                case Shapes.Free:
                    {
                        senName = "SendFree";
                        break;
                    }
            }

            var json = JsonConvert.SerializeObject(curShape);
            connection.InvokeAsync(senName, "TestUser", json);

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && startPoint != null)
            {
                endPoint = e.Location;

                curShape.UpdateShape((Point)startPoint, (Point)endPoint);

                pictureBox1.Invalidate();

                previous = new Point(e.X, e.Y);
            }


        }

        private Shape ObjectShape(Shapes shape)
        {
            switch (shape)
            {
                case Shapes.Line:
                    return new Line(pen);
                    break;
                case Shapes.Rect:
                    return new Rect(pen);
                    break;
                case Shapes.Circle:
                    return new Circle(pen);
                    break;
                default:
                    return new FreeDraw(pen);
                    break;
            }
        }

        private void colorlbl_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen = new Pen(colorDialog1.Color, pen.Width);
                colorlbl.BackColor = colorDialog1.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen = new Pen(colorlbl.BackColor, (float)numericUpDown1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                currentShapeType = Shapes.Line;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                currentShapeType = Shapes.Rect;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                currentShapeType = Shapes.Circle;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (shapes.Any())
            {
                undoshapes.Push(shapes.Pop());
                pictureBox1.Invalidate();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                currentShapeType = Shapes.Free;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (undoshapes.Any())
            {
                shapes.Push(undoshapes.Pop());
                pictureBox1.Invalidate();
            }
        }
    }
}
