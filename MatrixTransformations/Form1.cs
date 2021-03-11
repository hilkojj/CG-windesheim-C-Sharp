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
            xAxis.applyMatrix(camera.GetViewMatrix());
            yAxis.applyMatrix(camera.GetViewMatrix());
            zAxis.applyMatrix(camera.GetViewMatrix());
            xAxis.applyProjectionMatrix(camera);
            yAxis.applyProjectionMatrix(camera);
            zAxis.applyProjectionMatrix(camera);


    

            // Create object
            cube = new Cube(Color.Purple, 5);
            dube = new Cube(Color.Orange, 2);
            bube = new Cube(Color.Crimson, 10);
            

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            camera.Update();
            Console.WriteLine(camera.r);

            // Draw axes
            // xAxis.Draw(e.Graphics, Transform(xAxis.vb));
            // yAxis.Draw(e.Graphics, Transform(yAxis.vb));
            // zAxis.Draw(e.Graphics, Transform(zAxis.vb));

            // Draw cube


            // cube.Draw(e.Graphics, camera, WIDTH, HEIGHT);
            dube.Draw(e.Graphics, camera, WIDTH, HEIGHT);
            // bube.Draw(e.Graphics, camera, WIDTH, HEIGHT);
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            else if (e.KeyCode == Keys.R)
                camera.r += .1f * (Control.ModifierKeys == Keys.Shift ? -1 : 1);

            this.Refresh();
        }
    }
}
