using System;
using System.Collections.Generic;
using System.Drawing;

namespace MatrixTransformations
{
    public class Cube
    {

        //          7----------4
        //         /|         /|
        //        / |        / |                y
        //       /  6-------/--5                |
        //      3----------0  /                 ----x
        //      | /        | /                 /
        //      |/         |/                  z
        //      2----------1

        private float size = 1;
        public List<Vector> vertexbuffer; 

        Color col;

        public Cube(Color c, float size) { 
            col = c;
            this.size = size / 2;
            vertexbuffer = new List<Vector>
        {
            new Vector( this.size,  this.size, this.size),     //0
            new Vector( this.size, -this.size, this.size),     //1
            new Vector(-this.size, -this.size, this.size),     //2
            new Vector(-this.size,  this.size, this.size),     //3

            new Vector( this.size,  this.size, -this.size),    //4
            new Vector( this.size, -this.size, -this.size),    //5
            new Vector(-this.size, -this.size, -this.size),    //6
            new Vector(-this.size,  this.size, -this.size),    //7
        };
        }

        public void Draw(Graphics g, List<Vector> vb)
        {
            Pen pen = new Pen(col, 2f);
            g.DrawLine(pen, vb[0].x, vb[0].y, vb[1].x, vb[1].y);    //0 -> 1
            g.DrawLine(pen, vb[1].x, vb[1].y, vb[2].x, vb[2].y);    //1 -> 2
            g.DrawLine(pen, vb[2].x, vb[2].y, vb[3].x, vb[3].y);    //2 -> 3
            g.DrawLine(pen, vb[3].x, vb[3].y, vb[0].x, vb[0].y);    //3 -> 0

            g.DrawLine(pen, vb[4].x, vb[4].y, vb[5].x, vb[5].y);    //4 -> 5
            g.DrawLine(pen, vb[5].x, vb[5].y, vb[6].x, vb[6].y);    //5 -> 6
            g.DrawLine(pen, vb[6].x, vb[6].y, vb[7].x, vb[7].y);    //6 -> 7
            g.DrawLine(pen, vb[7].x, vb[7].y, vb[4].x, vb[4].y);    //7 -> 4

            g.DrawLine(pen, vb[0].x, vb[0].y, vb[4].x, vb[4].y);    //0 -> 4
            g.DrawLine(pen, vb[1].x, vb[1].y, vb[5].x, vb[5].y);    //1 -> 5
            g.DrawLine(pen, vb[2].x, vb[2].y, vb[6].x, vb[6].y);    //2 -> 6
            g.DrawLine(pen, vb[3].x, vb[3].y, vb[7].x, vb[7].y);    //3 -> 7

            /*Font font = new Font("Arial", 12, FontStyle.Bold);
            for (int i = 0; i < 8; i++)
            {
                PointF p = new PointF(vb[i + 8].x, vb[i + 8].y);
                g.DrawString(i.ToString(), font, Brushes.Black, p);
            }*/
        }

        public void applyMatrix(Matrix matrix)
        {
            for (int i = 0; i < 8; i++)
            {
                vertexbuffer[i] = matrix * vertexbuffer[i];
            }
        }
    }
}
