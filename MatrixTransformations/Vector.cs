using System;
using System.Text;

namespace MatrixTransformations
{
    public class Vector
    {
        public float x, y, z, w;

        public Vector(float x, float y, float z = 0, float w = 1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector() : this(0, 0) { }

        public float Length() {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }


        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.w + v2.w);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.w - v2.w);
        }

        public static Vector operator *(Vector v, float d) {
            return new Vector(v.x * d, v.y * d, v.w * d);
        }

        public static Vector operator *(float d, Vector v)
        {
            return v * d;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("X: ").Append(this.x)
                                                .Append(", Y:").Append(this.y)
                                                .Append(", Z:").Append(this.z)
                                                .Append(", W:").Append(this.w);
            return sb.ToString();
        }
    }
}
