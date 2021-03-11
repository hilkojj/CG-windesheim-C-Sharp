using System;
using System.Text;

namespace MatrixTransformations
{
    public class Matrix
    {
        private const int dims = 4;
        public float[,] mat = new float[dims, dims];

        public Matrix() : this(1, 0, 0, 1) { }

        public Matrix(float m11, float m12, float m21, float m22) : this(m11, m12, 0,
                                                                         m21, m22, 0,
                                                                         0,   0,   1) { }

        public Matrix(float m11, float m12, float m13,
                      float m21, float m22, float m23,
                      float m31, float m32, float m33) : this(m11, m12, m13, 0,
                                                              m21, m22, m23, 0,
                                                              m31, m32, m33, 0,
                                                              0,   0,   0,   1) { }

        public Matrix(float m11, float m12, float m13, float m14,
                      float m21, float m22, float m23, float m24,
                      float m31, float m32, float m33, float m34,
                      float m41, float m42, float m43, float m44)
        {
            mat[0, 0] = m11; mat[0, 1] = m12; mat[0, 2] = m13; mat[0, 3] = m14;
            mat[1, 0] = m21; mat[1, 1] = m22; mat[1, 2] = m23; mat[1, 3] = m24;
            mat[2, 0] = m31; mat[2, 1] = m32; mat[2, 2] = m33; mat[2, 3] = m34;
            mat[3, 0] = m41; mat[3, 1] = m42; mat[3, 2] = m43; mat[3, 3] = m44;
        }

        public Matrix(Vector v) : this(v.x, 0, 0, 0,
                                       v.y, 0, 0, 0,
                                       v.z, 0, 0, 0,
                                       1, 0, 0, 0) { }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix();

            for (int i = 0; i < dims; i++) {
                for (int j = 0; j < dims; j++) {
                    result.mat[i, j] = m1.mat[i, j] + m2.mat[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix();

            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    result.mat[i, j] = m1.mat[i, j] - m2.mat[i, j];
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix m1, float f)
        {
            Matrix result = new Matrix();

            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    result.mat[i, j] = m1.mat[i, j] * f;
                }
            }
            return result;
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            return m1 * f;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix();

            for (int i = 0; i < dims; i++) {
                for (int j = 0; j < dims; j++) {

                    result.mat[i, j] = 0;

                    for (int k = 0; k < dims; k++)
                    result.mat[i, j] += m1.mat[i, k] * m2.mat[k, j];
                }
            }

            return result;
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            Matrix result = m1 * new Matrix(v);
            return result.ToVector();
        }

        public static Matrix Identity()
        {
            return new Matrix();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dims; i++) {
                sb.Append("[ ");
                for (int j = 0; j < dims; j++) {
                    sb.Append(mat[i, j]).Append(", ");
                }
                sb.Append("]");
            }
            return sb.ToString();
        }

        public Vector ToVector() {
            return new Vector(this.mat[0, 0], this.mat[1, 0], this.mat[2, 0]);
        }

        public static Matrix getScalingMatrix(float size) {
            Matrix result = new Matrix() * size;
            result.mat[4, 4] = 1;
            return result;
        }

        public static Matrix getRotationMatrix2D(float angleInRadians) {

            //Console.WriteLine("Rotate matrix prepared.");
            return new Matrix((float) Math.Cos(angleInRadians),
                (float) -Math.Sin(angleInRadians),
                (float) Math.Sin(angleInRadians),
                (float) Math.Cos(angleInRadians));
        }

        public static Matrix getXRotationMatrix(float angleInRadians) {
            return new Matrix(1, 0, 0,
                              0, (float) Math.Cos(angleInRadians), (float) -Math.Sin(angleInRadians),
                              0, (float) Math.Sin(angleInRadians), (float) Math.Cos(angleInRadians));
        }

        public static Matrix getYRotationMatrix(float angleInRadians)
        {
            return new Matrix((float) Math.Cos(angleInRadians), 0, (float) Math.Sin(angleInRadians),
                              0, 1, 0, 
                              (float) -Math.Sin(angleInRadians), 0, (float)Math.Cos(angleInRadians));
        }

        public static Matrix getZRotationMatrix(float angleInRadians)
        {
            return Matrix.getRotationMatrix2D(angleInRadians);
        }

        public static Matrix getTranslationMatrix3D(float tx, float ty, float tz) {
            return new Matrix(1, 0, 0, tx,
                              0, 1, 0, ty,
                              0, 0, 1, tz,
                              0, 0, 0, 1);
        }
    }
}
