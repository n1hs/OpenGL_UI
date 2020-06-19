using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class Sphere : Graphic3D
    {
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public double LocationZ { get; private set; }

        public double SizeX { get; private set; }
        public double SizeY { get; private set; }
        public double SizeZ { get; private set; }

        public double ColorR { get; private set; }
        public double ColorG { get; private set; }
        public double ColorB { get; private set; }

        public double RotateX { get; private set; }
        public double RotateY { get; private set; }
        public double RotateZ { get; private set; }

        public string Name { get; private set; }

        public DrawStyle Style { get; private set; }
        public Sphere(double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Name = "Sphere";
            SizeX = baseRadius;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;

        }
        public void DrawPoint(OpenGL gl)
        {
        }
        public void DrawLine(OpenGL gl)
        {
        }
        //ham ve hinh non
        public void DrawSolid(OpenGL gl)
        {
        }

        public static Sphere DrawSpherePoint(OpenGL gl, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0)
        {
            return null;
        }
        public static Sphere DrawSphereLine(OpenGL gl, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0)
        {
            return null;
        }


        public static Sphere DrawSphereSolid(OpenGL gl, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0)
        {
            return null;
        }

    }
}

