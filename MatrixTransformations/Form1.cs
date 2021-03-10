using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixTransformations
{
    public partial class Form1 : Form
    {
        // Axes
        AxisX x_axis;
        AxisY y_axis;

        // Objects
        Square squara;
        Square squarb;
        Square squarc;
        Square squard;
        Cube cube;
        Camera camera;

        // Window dimensions
        const int WIDTH = 800;
        const int HEIGHT = 600;

        public Form1()
        {
            InitializeComponent();

            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.DoubleBuffered = true;
            camera = new Camera(200, (float)(Math.PI / 6), (float)(Math.PI / 4));

            // Define axes
            x_axis = new AxisX(200);
            y_axis = new AxisY(200);

            // Create object
            cube = new Cube(Color.Purple, 120);
            cube.applyMatrix(camera.GetViewMatrix());
            /*squara = new Square(Color.Purple,100);
            squarb = new Square(Color.Turquoise, 100);
            squarc = new Square(Color.Red, 100);
            squard = new Square(Color.Blue, 100);
            squarb.applyMatrix(Matrix.getScalingMatrix(0.5f));
            squarc.applyMatrix(Matrix.getRotationMatrix2D((float)(Math.PI / 12)));
            squard.applyMatrix(Matrix.getTranslationMatrix3D(30.0f, 10.0f, 0f));*/
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw axes
            x_axis.Draw(e.Graphics, Transform(x_axis.vb));
            y_axis.Draw(e.Graphics, Transform(y_axis.vb));

            // Draw square
            cube.Draw(e.Graphics, Transform(cube.vertexbuffer));
            /*squara.Draw(e.Graphics, Transform(squara.vb));
            squarb.Draw(e.Graphics, Transform(squarb.vb));
            squarc.Draw(e.Graphics, Transform(squarc.vb));
            squard.Draw(e.Graphics, Transform(squard.vb));*/
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        public static List<Vector> Transform(List<Vector> origin, float delta_x = WIDTH / 2, float delta_y = HEIGHT / 2) {
            List<Vector> result = new List<Vector>();

            foreach (Vector v in origin) {
                result.Add(new Vector(v.x + delta_x, delta_y - v.y));
            };

            return result;
        }
    }
}
