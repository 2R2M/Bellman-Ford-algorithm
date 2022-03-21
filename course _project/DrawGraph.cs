using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace course_project 
{
        class DrawGraph
        {
            public static List<Edges> edg;
            public static Dictionary<int, PointF> DictPoint;
            public Edges edge;
            Pen blackPen;
            Font font;
            Brush brush;
            PointF point;
            Random random;
            public int R = 20;
            int range1;
            int range2;


            public DrawGraph(int width, int height, int rnd1, int rnd2)
            {
             
                blackPen = new Pen(Color.Black, 2);
                font = new Font("Arial", 15);
                brush = Brushes.Black;
                DictPoint = new Dictionary<int, PointF>() { };
                edg = new List<Edges>() { };
                edge = new Edges();
                random = new Random();
                range1 = rnd1;
                range2 = rnd2;

            }

            public void DrawVert(PointF pointF, int number, PaintEventArgs e)
            {
                RectangleF rectangle = new RectangleF(pointF.X, pointF.Y, 2 * R, 2 * R);
                e.Graphics.DrawEllipse(blackPen, rectangle);
                e.Graphics.FillEllipse(Brushes.White, pointF.X, pointF.Y, 2 * R, 2 * R);
                e.Graphics.DrawString((number+1).ToString(), font, brush, pointF.X + 10, pointF.Y + 10);
            }

            public void DrawEdge(Edges edges, Dictionary<int, PointF> DicPoint, PaintEventArgs e)
            {
            if (edges.w != 0)
            {
                if (edges.u != edges.v)
                {
                    e.Graphics.DrawLine(blackPen, DicPoint[edges.u].X + 15, DicPoint[edges.u].Y + 15, DicPoint[edges.v].X + 15, DicPoint[edges.v].Y + 15);
                    point = new PointF((DicPoint[edges.u].X + DicPoint[edges.v].X) / 2, (DicPoint[edges.u].Y + DicPoint[edges.v].Y) / 2);


                    e.Graphics.DrawString(edges.w.ToString(), font, brush, point.X + 15, point.Y + 15);

                    DrawVert(DicPoint[edges.u], edges.u, e);
                    DrawVert(DicPoint[edges.v], edges.v, e);
                }
            }
            }
         
            public void CreatePoint(Edges new_edge)
            {

                edge.u = new_edge.u;
                edge.v = new_edge.v;
                edge.w = new_edge.w;
 
                PointF p = new PointF(random.Next(range1-300, range1), random.Next(range2-300, range2));
                PointF p2 = new PointF(p.X + 100, p.Y + 100);
                edg.Add(edge);
                if (!DictPoint.ContainsKey(new_edge.u))
                {
                    DictPoint.Add(new_edge.u, p);
                }
                if (!DictPoint.ContainsKey(new_edge.v))
                {
                    DictPoint.Add(new_edge.v, p2);
                }
            }
            public void DrawClear(PaintEventArgs e)
            {
                e.Graphics.Clear(Color.White);
            }

        }   
}
