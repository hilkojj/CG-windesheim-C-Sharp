using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixTransformations;

namespace UnitTests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Vector3 vec = new Vector3(1, 2, 3);

            Assert.AreEqual(1, vec.x);
            Assert.AreEqual(2, vec.y);
            Assert.AreEqual(3, vec.z);

            Vector4 vec4 = new Vector4(vec, 4);

            Assert.AreEqual(1, vec4.x);
            Assert.AreEqual(2, vec4.y);
            Assert.AreEqual(3, vec4.z);
            Assert.AreEqual(4, vec4.w);

            vec4 = new Vector4(1, 2, 3, 4);

            Assert.AreEqual(1, vec4.x);
            Assert.AreEqual(2, vec4.y);
            Assert.AreEqual(3, vec4.z);
            Assert.AreEqual(4, vec4.w);
        }

        [TestMethod]
        public void AddOperatorTest()
        {
            Vector3 vec0 = new Vector3(1, 2, 3);
            Vector3 vec1 = new Vector3(1, 2, 3);

            Vector3 vec = vec0 + vec1;
            Assert.AreEqual(2, vec.x);
            Assert.AreEqual(4, vec.y);
            Assert.AreEqual(6, vec.z);
        }

        [TestMethod]
        public void SubtractOperatorTest()
        {
            Vector3 vec0 = new Vector3(1, 2, 3);
            Vector3 vec1 = new Vector3(1, 1, 1);

            Vector3 vec = vec0 - vec1;
            Assert.AreEqual(0, vec.x);
            Assert.AreEqual(1, vec.y);
            Assert.AreEqual(2, vec.z);
        }

        [TestMethod]
        public void MultiplyOperatorTest()
        {
            Vector3 vec = new Vector3(1, 2, 3);
            float x = 10;

            vec *= x;

            Assert.AreEqual(10, vec.x);
            Assert.AreEqual(20, vec.y);
            Assert.AreEqual(30, vec.z);
        }
    }
}
