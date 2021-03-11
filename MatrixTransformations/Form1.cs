using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixTransformations
{
    public partial class Form1 : Form
    {
        // Axes
        Axis x_axis;
        Axis y_axis;
        Axis z_axis;

        Cube cube;
        Cube dube;
        Cube bube;
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
            camera = new Camera(10, (float)(Math.PI / 180 * -285), (float)(Math.PI / 180 * 74));

            // Define axes
            x_axis = new Axis(Axis.Which.X, 2);
            y_axis = new Axis(Axis.Which.Y, 2);
            z_axis = new Axis(Axis.Which.Z, 2);
            x_axis.applyMatrix(camera.GetViewMatrix());
            y_axis.applyMatrix(camera.GetViewMatrix());
            z_axis.applyMatrix(camera.GetViewMatrix());
            x_axis.applyProjectionMatrix(camera);
            y_axis.applyProjectionMatrix(camera);
            z_axis.applyProjectionMatrix(camera);

            // Create object
            cube = new Cube(Color.Purple, 10);
            dube = new Cube(Color.Orange, 2);
            bube = new Cube(Color.Crimson, 280);
            cube.applyMatrix(camera.GetViewMatrix());
            dube.applyMatrix(camera.GetViewMatrix());
            bube.applyMatrix(camera.GetViewMatrix());
            cube.applyProjectionMatrix(camera);
            dube.applyProjectionMatrix(camera);
            bube.applyProjectionMatrix(camera);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw axes
            x_axis.Draw(e.Graphics, Transform(x_axis.vb));
            y_axis.Draw(e.Graphics, Transform(y_axis.vb));
            z_axis.Draw(e.Graphics, Transform(z_axis.vb));

            // Draw cube
            //cube.Draw(e.Graphics, Transform(cube.vertexbuffer));
            dube.Draw(e.Graphics, Transform(dube.vertexbuffer));
            //bube.Draw(e.Graphics, Transform(bube.vertexbuffer));
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
