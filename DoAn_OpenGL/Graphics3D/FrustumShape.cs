using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class FrustumShape : Graphic3D
    {
        public FrustumShape(DrawStyle style, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "FrustumShape";
            SizeX = baseRadius;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;

        }
        public override void DrawPoint(OpenGL gl)
        {
        }
        public override void DrawLine(OpenGL gl)
        {
        }
        //ham ve hinh non
        public override void DrawSolid(OpenGL gl)
        {
        }

    }
}
