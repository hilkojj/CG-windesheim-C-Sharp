using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransformations
{
    class NewMatrix
    {
        private const int dims = 4;
        public float[,] mat = new float[dims, dims];

        public NewMatrix() : this(1, 0, 0, 1) { }

        public NewMatrix(float m11, float m12, float m21, float m22) : this(m11, m12, 0,
                                                                         m21, m22, 0,
                                                                         0, 0, 1)
        { }

        public NewMatrix(float m11, float m12, float m13,
                      float m21, float m22, float m23,
                      float m31, float m32, float m33)
        {
            mat[0, 0] = m11; mat[0, 1] = m12; mat[0, 2] = m13;
            mat[1, 0] = m21; mat[1, 1] = m22; mat[1, 2] = m23;
            mat[2, 0] = m31; mat[2, 1] = m32; mat[2, 2] = m33;
        }

        public NewMatrix(float m11, float m12, float m13, float m14,
                      float m21, float m22, float m23, float m24,
                      float m31, float m32, float m33, float m34,
                      float m41, float m42, float m43, float m44)
        {
            mat[0, 0] = m11; mat[0, 1] = m12; mat[0, 2] = m13; mat[0, 3] = m14;
            mat[1, 0] = m21; mat[1, 1] = m22; mat[1, 2] = m23; mat[1, 3] = m24;
            mat[2, 0] = m31; mat[2, 1] = m32; mat[2, 2] = m33; mat[2, 3] = m34;
            mat[3, 0] = m41; mat[3, 1] = m42; mat[3, 2] = m43; mat[3, 3] = m44;
        }

        public NewMatrix(Vector v) : this(v.x, 0, 0, v.y, 0, 0, 1, 0, 0) { }

        public static NewMatrix operator +(NewMatrix m1, NewMatrix m2)
        {
            NewMatrix result = new NewMatrix();

            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    result.mat[i, j] = m1.mat[i, j] + m2.mat[i, j];
                }
            }
            return result;
        }

        public static NewMatrix operator -(NewMatrix m1, NewMatrix m2)
        {
            NewMatrix result = new NewMatrix();

            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    result.mat[i, j] = m1.mat[i, j] - m2.mat[i, j];
                }
            }
            return result;
        }
        public static NewMatrix operator *(NewMatrix m1, float f)
        {
            NewMatrix result = new NewMatrix();

            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    result.mat[i, j] = m1.mat[i, j] * f;
                }
            }
            return result;
        }

        public static NewMatrix operator *(float f, NewMatrix m1)
        {
            return m1 * f;
        }

        public static NewMatrix operator *(NewMatrix m1, NewMatrix m2)
        {
            NewMatrix result = new NewMatrix();

            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {

                    result.mat[i, j] = 0;

                    for (int k = 0; k < dims; k++)
                        result.mat[i, j] += m1.mat[i, k] * m2.mat[k, j];
                }
            }

            return result;
        }

        public static Vector operator *(NewMatrix m1, Vector v)
        {
            NewMatrix result = m1 * new NewMatrix(v);
            return result.ToVector();
        }

        public static NewMatrix Identity()
        {
            return new NewMatrix();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dims; i++)
            {
                sb.Append("[ ");
                for (int j = 0; j < dims; j++)
                {
                    sb.Append(mat[i, j]).Append(", ");
                }
                sb.Append("]");
            }
            return sb.ToString();
        }

        public Vector ToVector()
        {
            return new Vector(this.mat[0, 0], this.mat[1, 0]);
        }

        public static NewMatrix getScalingMatrix(float size)
        {
            return new NewMatrix() * size;
        }

        public static NewMatrix getRotationMatrix(float angleInRadians)
        {

            Console.WriteLine("Rotate matrix prepared.");
            return new NewMatrix((float)Math.Cos(angleInRadians),
                (float)-Math.Sin(angleInRadians),
                (float)Math.Sin(angleInRadians),
                (float)Math.Cos(angleInRadians));
        }

        public static NewMatrix getTranslationMatrix(float tx, float ty)
        {
            Console.WriteLine("Translate matrix prepared.");
            return new NewMatrix(1, 0, tx,
                              0, 1, ty,
                              0, 0, 1);
        }
    }
}
