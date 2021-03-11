using System.Collections.Generic;
using System.Drawing;

namespace MatrixTransformations
{
    public class Axis
    {
        public enum Which {
            X,
            Y,
            Z
        }
        public List<Vector> vb;
        private Color color;
        private int size;
        private string label;

        public Axis(Which which, int size = 100)
        {
            this.size = size;
            vb = new List<Vector>();
            vb.Add(new Vector(0, 0));

            switch (which) {
                case Which.X:
                    vb.Add(new Vector(size, 0));
                    this.label = "x";
                    color = Color.Red;
                    break;
                case Which.Y:
                    vb.Add(new Vector(0, size));
                    this.label = "y";
                    color = Color.LightGreen;
                    break;
                case Which.Z:
                    vb.Add(new Vector(0, 0, size));
                    this.label = "z";
                    color = Color.Blue;
                    break;
            }
        }

        public void Draw(Graphics g, List<Vector> vb)
        {
            Pen pen = new Pen(color, 2f);
            g.DrawLine(pen, vb[0].x, vb[0].y, vb[1].x, vb[1].y);
            Font font = new Font("Arial", 10);
            PointF p = new PointF(vb[1].x, vb[1].y);
            g.DrawString(this.label, font, new SolidBrush(color), p);
        }

        public void applyMatrix(Matrix matrix)
        {
            for (int i = 0; i < vb.Count; i++)
                vb[i] = matrix * vb[i];
        }

        public void applyProjectionMatrix(Camera camera)
        {
            for (int i = 0; i < vb.Count; i++)
                vb[i] = camera.GetProjectionMatrix(vb[i]) * vb[i];
        }
    }
}
