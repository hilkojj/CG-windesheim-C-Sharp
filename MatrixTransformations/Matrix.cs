using System;
using System.Text;

namespace MatrixTransformations
{
    public class Matrix
    {
        float[,] mat = new float[2, 2];

        public Matrix()
        {
            throw new NotImplementedException();
        }
        public Matrix(float m11, float m12,
                      float m21, float m22)
        {
            mat[0, 0] = m11; mat[0, 1] = m12;
            mat[1, 0] = m21; mat[1, 1] = m22;
        }

        public Matrix(Vector v)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            throw new NotImplementedException();
        }
        public static Matrix operator *(Matrix m1, float f)
        {
            throw new NotImplementedException();
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            throw new NotImplementedException();
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            throw new NotImplementedException();
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            throw new NotImplementedException();
        }

        public static Matrix Identity()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
