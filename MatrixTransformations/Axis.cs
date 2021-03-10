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
        private int size;
        public List<Vector> vb;
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
                    break;
                case Which.Y:
                    vb.Add(new Vector(0, size));
                    this.label = "y";
                    break;
                case Which.Z:
                    vb.Add(new Vector(0, 0, size));
                    this.label = "z";
                    break;
            }
        }

        public void Draw(Graphics g, List<Vector> vb)
        {
            Pen pen = new Pen(Color.Red, 2f);
            g.DrawLine(pen, vb[0].x, vb[0].y, vb[1].x, vb[1].y);
            Font font = new Font("Arial", 10);
            PointF p = new PointF(vb[1].x, vb[1].y);
            g.DrawString(this.label, font, Brushes.Red, p);
        }

        public void applyMatrix(Matrix matrix)
        {
            //System.Console.WriteLine("Applying matrix " + matrix.ToString());
            for (int i = 0; i < vb.Count; i++)
            {
                vb[i] = matrix * vb[i];
            }
        }
    }
}
