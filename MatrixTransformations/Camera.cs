using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransformations
{
    public class Camera
    {
        private float d = 800;
        private Vector t;
        private float theta;
        private float phi;
        private float r;

        public Camera(float r, float theta, float phi) {
            this.t = new Vector((float)(r * Math.Sin(phi) * Math.Cos(theta)),
                                (float)(r * Math.Sin(phi) * Math.Sin(theta)),
                                (float)(r * Math.Cos(phi)),
                                0);
            this.theta = theta;
            this.phi = phi;
            this.r = r;
        }

        public Matrix GetCameraTranslationMatrix() {
            Matrix result = new Matrix();
            result.mat[0, 3] = -t.x;
            result.mat[1, 3] = -t.y;
            result.mat[2, 3] = -t.z;

            return result;
        }

        public Matrix GetXCorrectionMatrix() {
            return new Matrix(
                (float)(-Math.Sin(theta)),
                (float)( Math.Cos(theta)),
                (float)(-Math.Cos(theta)),
                (float)(-Math.Sin(theta)));
        }

        public Matrix GetYCorrectionMatrix() {
            return new Matrix(
                1, 0, 0,
                0, (float)( Math.Cos(phi)), (float)(Math.Sin(phi)),
                0, (float)(-Math.Sin(phi)), (float)(Math.Cos(phi)));
        }

        public Matrix GetViewMatrix() {
            return this.GetYCorrectionMatrix()
                * this.GetXCorrectionMatrix()
                * this.GetCameraTranslationMatrix();
        }

        public Matrix GetProjectionMatrix(Vector whereFrom) {
            float dv = d / -whereFrom.z;
            return new Matrix() * dv;
        }

    }
}
