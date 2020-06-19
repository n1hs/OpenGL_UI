using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class Cube : Graphic3D
    { 
        public Cube(DrawStyle style,double WidthX, double WidthY, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Cube";
            SizeX = WidthX;
            SizeY = WidthY;
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
