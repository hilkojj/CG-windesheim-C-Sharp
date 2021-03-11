using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixTransformations;

namespace UnitTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void IdentityTest()
        {
            Matrix4 id = new Matrix4();

            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    Assert.AreEqual(id.mat[x, y], x == y ? 1 : 0);
        }

        [TestMethod]
        public void MultiplyMatricesTest()
        {
            // https://ncalculators.com/matrix/4x4-matrix-multiplication-calculator.htm

            Matrix4 m0 = new Matrix4(
                5, 7, 9, 10,
                2, 3, 3, 8, 
                8, 10, 2, 3,
                3, 3, 4, 8
            );
            Matrix4 m1 = new Matrix4(
                3, 10, 12, 18,
                12, 1, 4, 9,
                9, 10, 12, 2,
                3, 12, 4, 10
            );

            Matrix4 result = m0 * m1;

            Matrix4 correctResult = new Matrix4(
                210, 267, 236, 271,
                93, 149, 104, 149,
                171, 146, 172, 268,
                105, 169, 128, 169
            );

            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    Assert.AreEqual(result.mat[x, y], correctResult.mat[x, y]);
        }

        [TestMethod]
        public void MultiplyMatrixWithPositionTest()
        {
            // http://www.opengl-tutorial.org/assets/images/tuto-3-matrix/translationExamplePosition1.png

            Matrix4 m = new Matrix4(
                1, 0, 0, 10,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );

            Vector4 vec = new Vector4(10, 10, 10, 1);

            vec = m * vec; // vec should be translated

            Assert.AreEqual(vec.x, 20);
            Assert.AreEqual(vec.y, 10);
            Assert.AreEqual(vec.z, 10);
            Assert.AreEqual(vec.w, 1);
        }

        [TestMethod]
        public void MultiplyMatrixWithDirectionTest()
        {
            // http://www.opengl-tutorial.org/assets/images/tuto-3-matrix/translationExampleDirection1.png

            Matrix4 m = new Matrix4(
                1, 0, 0, 10,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            );

            Vector4 vec = new Vector4(0, 0, -1, 0);

            vec = m * vec; // vec should NOT be translated, because it is a direction (w = 0)

            Assert.AreEqual(vec.x, 0);
            Assert.AreEqual(vec.y, 0);
            Assert.AreEqual(vec.z, -1);
            Assert.AreEqual(vec.w, 0);
        }
    }
}
