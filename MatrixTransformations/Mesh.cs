using System;
using System.Collections.Generic;
using System.Drawing;

namespace MatrixTransformations
{
    public class Mesh
    {
        public List<Vector> vertexbuffer;
        public float scale = 1;
        public Vector translate = new Vector();
        public Vector rotate = new Vector();

        public List<Vector> ToWindowCoordinates(Camera cam, float windowWidth, float windowHeight)
        {
            List<Vector> coords = new List<Vector>();

            Matrix modelTransform = Matrix.GetTranslationMatrix3D(translate.x, translate.y, translate.z)

                                    * Matrix.GetScalingMatrix(scale)

                                    * Matrix.GetXRotationMatrix(rotate.x)
                                    * Matrix.GetYRotationMatrix(rotate.y)
                                    * Matrix.GetZRotationMatrix(rotate.z);

            Matrix modelViewMatrix = cam.GetViewMatrix() * modelTransform;

            foreach (Vector v in vertexbuffer)
            {
                Vector coord = modelViewMatrix * v;
                coord = cam.GetProjectionMatrix(coord) * coord;
                coords.Add(coord);
            }

            return Transform2D(coords, windowWidth / 2, windowHeight / 2);
        }

        public void ApplyMatrix(Matrix mat)
        {
            for (int i = 0; i < vertexbuffer.Count; i++)
                vertexbuffer[i] = mat * vertexbuffer[i];
        }

        private static List<Vector> Transform2D(List<Vector> origin, float delta_x, float delta_y)
        {
            List<Vector> result = new List<Vector>();

            foreach (Vector v in origin)
                result.Add(new Vector(v.x + delta_x, delta_y - v.y));

            return result;
        }
    }
}
