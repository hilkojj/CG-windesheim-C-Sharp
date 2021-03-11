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
            ResetCamera();

            // Define axes
            xAxis = new Axis(Axis.Which.X);
            yAxis = new Axis(Axis.Which.Y);
            zAxis = new Axis(Axis.Which.Z);

            // Create cubes
            cube = new Cube(Color.Orange, 2);
            dube = new Cube(Color.Purple, 5);
            bube = new Cube(Color.Crimson, 10);
        }

        private void ResetCamera()
        {
            camera = new Camera(10, (float)(Math.PI / 180 * -285), (float)(Math.PI / 180 * 74));
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

            Font font = new Font("Arial", 12, FontStyle.Regular);
            e.Graphics.DrawString("" +
                "Scale:\n" +
                "Translate:\n" +
                "Rotate:\n\n" +
                "r:\n" +
                "d:\n" +
                "phi:\n" +
                "theta:\n\n" +
                "Phase:", font, Brushes.Black, new PointF(0, 0));

            e.Graphics.DrawString("" +
                "S/s\n" +
                "Arrows PgDn/PgUp\n" +
                "X/x Y/y Z/z\n\n" +
                "R/r\n" +
                "D/d\n" +
                "P/p\n" +
                "T/t\n\n" +
                "", font, Brushes.DarkGray, new PointF(80, 0));

            e.Graphics.DrawString("" +
                cube.scale.ToString() + "\n" +
                cube.translate.ToString() + "\n" +
                cube.rotate.ToString() + "\n\n" +
                camera.r.ToString() + "\n" +
                camera.d.ToString() + "\n" +
                camera.phi.ToString() + "\n" +
                camera.theta.ToString() + "\n\n" +
                "todo", font, Brushes.Black, new PointF(250, 0));
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            float shiftMultiplier = Control.ModifierKeys == Keys.Shift ? -1 : 1;

            if (e.KeyCode == Keys.Escape)
                Application.Exit();

            {
                // TRANSLATE CUBE:
                if (e.KeyCode == Keys.Left)
                    cube.translate.x += .1f;
                else if (e.KeyCode == Keys.Right)
                    cube.translate.x -= .1f;

                else if (e.KeyCode == Keys.Up)
                    cube.translate.y -= .1f;
                else if (e.KeyCode == Keys.Down)
                    cube.translate.y += .1f;

                else if (e.KeyCode == Keys.PageUp)
                    cube.translate.z += .1f;
                else if (e.KeyCode == Keys.PageDown)
                    cube.translate.z -= .1f;
            }
            {
                // ROTATE CUBE:
                float rotateAmount = (float)Math.PI * .01f * shiftMultiplier;

                if (e.KeyCode == Keys.X)
                    cube.rotate.x += rotateAmount;
                else if (e.KeyCode == Keys.Y)
                    cube.rotate.y += rotateAmount;
                else if (e.KeyCode == Keys.Z)
                    cube.rotate.z += rotateAmount;
            }
            {
                // SCALE CUBE:
                if (e.KeyCode == Keys.S)
                    cube.scale += shiftMultiplier * .1f;
            }

            {
                // CHANGE CAMERA:
                if (e.KeyCode == Keys.R)
                    camera.r += .1f * shiftMultiplier;
                else if (e.KeyCode == Keys.T)
                    camera.theta += .1f * shiftMultiplier;
                else if (e.KeyCode == Keys.P)
                    camera.phi += .1f * shiftMultiplier;
                else if (e.KeyCode == Keys.D)
                    camera.d += 10f * shiftMultiplier;
            }

            if (e.KeyCode == Keys.C)    // RESET ALL VARIABLES
            {
                ResetCamera();
                // RESET ALL TRANSLATION/ROTATION/SCALING
                cube.translate = new Vector();
                cube.rotate = new Vector();
                cube.scale = 1;
            }

            this.Refresh();
        }
    }
}
