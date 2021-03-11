using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixTransformations
{
    public partial class Form1 : Form
    {
        // Axes
        Axis xAxis;
        Axis yAxis;
        Axis zAxis;

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
            xAxis = new Axis(Axis.Which.X);
            yAxis = new Axis(Axis.Which.Y);
            zAxis = new Axis(Axis.Which.Z);

            // Create object
            cube = new Cube(Color.Orange, 2);
            dube = new Cube(Color.Purple, 5);
            bube = new Cube(Color.Crimson, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            camera.Update();

            // Draw axes
            xAxis.Draw(e.Graphics, camera, WIDTH, HEIGHT);
            yAxis.Draw(e.Graphics, camera, WIDTH, HEIGHT);
            zAxis.Draw(e.Graphics, camera, WIDTH, HEIGHT);

            // Draw cube
            // cube.Draw(e.Graphics, camera, WIDTH, HEIGHT);
            cube.Draw(e.Graphics, camera, WIDTH, HEIGHT);
            // bube.Draw(e.Graphics, camera, WIDTH, HEIGHT);
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            else if (e.KeyCode == Keys.R)
                camera.r += .1f * (Control.ModifierKeys == Keys.Shift ? -1 : 1);

            {
                // TRANSLATE CUBE:

                Vector translateCube = new Vector();

                if (e.KeyCode == Keys.Left)
                    translateCube.x += .1f;
                else if (e.KeyCode == Keys.Right)
                    translateCube.x -= .1f;

                else if (e.KeyCode == Keys.Up)
                    translateCube.y -= .1f;
                else if (e.KeyCode == Keys.Down)
                    translateCube.y += .1f;

                else if (e.KeyCode == Keys.PageUp)
                    translateCube.z += .1f;
                else if (e.KeyCode == Keys.PageDown)
                    translateCube.z -= .1f;


                cube.ApplyMatrix(
                    Matrix.GetTranslationMatrix3D(translateCube.x, translateCube.y, translateCube.z)
                );
            }
            this.Refresh();
        }
    }
}
