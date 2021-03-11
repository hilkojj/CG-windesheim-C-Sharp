﻿using System;
using System.Text;

namespace MatrixTransformations
{
    /**
     * 
     * A good explanation of matrices:
     * http://www.opengl-tutorial.org/beginners-tutorials/tutorial-3-matrices/
     * and
     * https://vitaminac.github.io/Matrices-in-Computer-Graphics/
     * 
     **/
    public class Matrix4
    {
        public float[,] mat = new float[4, 4];

        public Matrix4() : this(1, 0, 0, 0,
                                0, 1, 0, 0,
                                0, 0, 1, 0,
                                0, 0, 0, 1)
        {
        }

        public Matrix4(float m00, float m10, float m20, float m30,
                       float m01, float m11, float m21, float m31,
                       float m02, float m12, float m22, float m32,
                       float m03, float m13, float m23, float m33)
        {
            mat[0, 0] = m00; mat[1, 0] = m10; mat[2, 0] = m20; mat[3, 0] = m30;
            mat[0, 1] = m01; mat[1, 1] = m11; mat[2, 1] = m21; mat[3, 1] = m31;
            mat[0, 2] = m02; mat[1, 2] = m12; mat[2, 2] = m22; mat[3, 2] = m32;
            mat[0, 3] = m03; mat[1, 3] = m13; mat[2, 3] = m23; mat[3, 3] = m33;
        }

        public Matrix4(Vector4 vec)
        {
            mat[0, 0] = vec.x;
            mat[0, 1] = vec.y;
            mat[0, 2] = vec.z;
            mat[0, 3] = vec.w;
        }

        public Vector4 ToVector4()
        {
            return new Vector4(mat[0, 0], mat[0, 1], mat[0, 2], mat[0, 3]);
        }
    
        public static Matrix4 operator +(Matrix4 m1, Matrix4 m2)
        {
            Matrix4 result = new Matrix4();
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    result.mat[x, y] = m1.mat[x, y] + m2.mat[x, y];
            return result;
        }

        public static Matrix4 operator -(Matrix4 m1, Matrix4 m2)
        {
            Matrix4 result = new Matrix4();
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    result.mat[x, y] = m1.mat[x, y] - m2.mat[x, y];
            return result;
        }

        public static Matrix4 operator *(Matrix4 m1, float f)
        {
            Matrix4 result = new Matrix4();
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                    result.mat[x, y] = m1.mat[x, y] * f;
            return result;
        }

        public static Matrix4 operator *(float f, Matrix4 m1)
        {
            return m1 * f;
        }

        public static Matrix4 operator *(Matrix4 m1, Matrix4 m2)
        {
            Matrix4 result = new Matrix4();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    result.mat[col, row] = 0;
                    for (int i = 0; i < 4; i++)
                        result.mat[col, row] += m1.mat[i, row] * m2.mat[col, i];
                }
            }
            return result;
        }

        public static Vector4 operator *(Matrix4 m1, Vector4 v)
        {
            return (m1 * new Matrix4(v)).ToVector4();
        }

        public static Matrix4 Identity()
        {
            return new Matrix4();
        }

        public override string ToString()
        {
            String result = "[\n";

            for (int y = 0; y < 4; y++)
            {
                result += "  ";
                for (int x = 0; x < 4; x++)
                    result += ("" + Math.Round(mat[x, y], 4)).PadLeft(9) + ", ";
                result += "\n";
            }
            return result + "]";
        }
    }
}
