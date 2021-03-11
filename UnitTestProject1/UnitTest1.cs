using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVector()
        {
            MatrixTransformations.Vector a = new MatrixTransformations.Vector(2, 3);
            MatrixTransformations.Vector b = new MatrixTransformations.Vector(-2, 3);

            Assert.AreEqual((a + b).x, 0);
            Assert.AreEqual((a + b).y, 6);

            Assert.AreEqual((a * 2).x, 4);
            Assert.AreEqual((2 * a).x, 4);

            MatrixTransformations.Vector c = new MatrixTransformations.Vector();

            Assert.AreEqual(c.x, 0);
            Assert.AreEqual(c.y, 0);
        }

        [TestMethod]
        public void TestMatrix()
        {
            MatrixTransformations.Matrix a = new MatrixTransformations.Matrix(2, 4, -1, 3);
            MatrixTransformations.Matrix b = new MatrixTransformations.Matrix(1, 3, 2, 1);

            MatrixTransformations.Matrix c = a * b;

            Assert.AreEqual(c.mat[0, 0], 10);
            Assert.AreEqual(c.mat[0, 1], 10);
            Assert.AreEqual(c.mat[1, 0], 5);
            Assert.AreEqual(c.mat[1, 1], 0);

            Assert.AreEqual(MatrixTransformations.Matrix.GetScalingMatrix(3).mat[0, 0], 3);
        }

        [TestMethod]
        public void TestCamera()
        {
            float r = 2;
            float theta = (float)Math.PI / 12;
            float phi = (float)Math.PI / 8;
            MatrixTransformations.Camera c
                = new MatrixTransformations.Camera(r, theta, phi);
            MatrixTransformations.Matrix vm = c.GetViewMatrix();
            MatrixTransformations.Matrix tm = c.GetCameraTranslationMatrix();
            MatrixTransformations.Matrix xm = c.GetXCorrectionMatrix();
            MatrixTransformations.Matrix ym = c.GetYCorrectionMatrix();

            Assert.AreEqual(1, tm.mat[0, 0]);
            Assert.AreEqual(0, tm.mat[0, 1]);
            Assert.AreEqual(-r * (float)Math.Sin(phi) * (float)Math.Cos(theta), tm.mat[0, 3], 0.001);
            Assert.AreEqual(-r * (float)Math.Sin(phi) * (float)Math.Sin(theta), tm.mat[1, 3], 0.001);
            Assert.AreEqual(-r * (float)Math.Cos(phi), tm.mat[2, 3], 0.001);
            Assert.AreEqual(1, tm.mat[3, 3]);

            Assert.AreEqual(-(float)Math.Sin(theta), xm.mat[0, 0], 0.001);
            Assert.AreEqual( (float)Math.Cos(theta), xm.mat[0, 1], 0.001);
            Assert.AreEqual(-(float)Math.Cos(theta), xm.mat[1, 0], 0.001);
            Assert.AreEqual(-(float)Math.Sin(theta), xm.mat[1, 1], 0.001);

            Assert.AreEqual(1, ym.mat[0, 0]);
            Assert.AreEqual(0, ym.mat[0, 1]);
            Assert.AreEqual((float)Math.Cos(phi), ym.mat[1, 1], 0.001);
            Assert.AreEqual((float)Math.Sin(phi), ym.mat[1, 2], 0.001);
            Assert.AreEqual((float)-Math.Sin(phi), ym.mat[2, 1], 0.001);
            Assert.AreEqual((float)Math.Cos(phi), ym.mat[2, 2], 0.001);
             

            Assert.AreEqual((float)-Math.Sin(theta), vm.mat[0, 0], 0.001);
            Assert.AreEqual((float) Math.Cos(theta), vm.mat[0, 1], 0.001);
            Assert.AreEqual(0, vm.mat[0, 2], 0.001);
            Assert.AreEqual(0, vm.mat[0, 3], 0.001);

            Assert.AreEqual((float)-Math.Cos(theta) * Math.Cos(phi), vm.mat[1, 0], 0.001);
            Assert.AreEqual((float)-Math.Sin(theta) * Math.Cos(phi), vm.mat[1, 1], 0.001);
            Assert.AreEqual((float) Math.Sin(phi), vm.mat[1, 2], 0.001);
            Assert.AreEqual(0, vm.mat[1, 3], 0.001);

            Assert.AreEqual((float) Math.Cos(theta) * Math.Sin(phi), vm.mat[2, 0], 0.001);
            Assert.AreEqual((float) Math.Sin(theta) * Math.Sin(phi), vm.mat[2, 1], 0.001);
            Assert.AreEqual((float) Math.Cos(phi), vm.mat[2, 2], 0.001);
            Assert.AreEqual(-r, vm.mat[2, 3], 0.001);

            Assert.AreEqual(0, vm.mat[3, 0], 0.001);
            Assert.AreEqual(0, vm.mat[3, 1], 0.001);
            Assert.AreEqual(0, vm.mat[3, 2], 0.001);
            Assert.AreEqual(1, vm.mat[3, 3], 0.001);
        }
    }
}
