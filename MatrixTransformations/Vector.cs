using System;
using System.Text;

namespace MatrixTransformations
{
    public class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 v1, float x)
        {
            return new Vector3(v1.x * x, v1.y * x, v1.z * x);
        }

        public static Vector3 operator *(float x, Vector3 v1)
        {
            return v1 * x;
        }

        // TODO: add more operators, but it is not necessary for this assignment.

        public override string ToString()
        {
            return "vec3(" + x + ", " + y + ", " + z + ")";
        }
    }

    public class Vector4 : Vector3 {

        public float w;

        public Vector4()
        {
        }

        public Vector4(Vector3 vec3, float w) : this(vec3.x, vec3.y, vec3.z, w)
        {
        }

        public Vector4(float x, float y, float z, float w) : base(x, y, z)
        {
            this.w = w;
        }

        // TODO: override operators, but it is not necessary for this assignment.

        public override string ToString()
        {
            return "vec4(" + x + ", " + y + ", " + z + ", " + w + ")";
        }
    }

}
