using System.Collections.Generic;
using System.Drawing;

namespace MatrixTransformations
{
    public class Axis : Mesh
    {
        public enum Which {
            X,
            Y,
            Z
        }
        private Color color;
        private int size;
        private string label;

        public Axis(Which which, int size = 3)
        {
            this.size = size;
            vertexbuffer = new List<Vector>();
            vertexbuffer.Add(new Vector(0, 0));

            switch (which) {
                case Which.X:
                    vertexbuffer.Add(new Vector(size, 0));
                    this.label = "x";
                    color = Color.Red;
                    break;
                case Which.Y:
                    vertexbuffer.Add(new Vector(0, size));
                    this.label = "y";
                    color = Color.LightGreen;
                    break;
                case Which.Z:
                    vertexbuffer.Add(new Vector(0, 0, size));
                    this.label = "z";
                    color = Color.Blue;
                    break;
            }
        }

        public void Draw(Graphics g, Camera cam, float windowWidth, float windowHeight)
        {
            List<Vector> vb = ToWindowCoordinates(cam, windowWidth, windowHeight);

            Pen pen = new Pen(color, 2f);
            g.DrawLine(pen, vb[0].x, vb[0].y, vb[1].x, vb[1].y);
            Font font = new Font("Arial", 10);
            PointF p = new PointF(vb[1].x, vb[1].y);
            g.DrawString(this.label, font, new SolidBrush(color), p);
        }
    }
}
