using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class Pyramid : Graphic3D
    {
        public Pyramid(DrawStyle style, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Pyramid";
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

            gl.PushMatrix();
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            // Draw the base square
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-1, 0, -1);
            gl.Vertex(-1, 0, 1);
            gl.Vertex(1, 0, 1);
            gl.Vertex(1, 0, -1);
            gl.End();

            // Draw four side triangles
            gl.Begin(OpenGL.GL_TRIANGLE_FAN);

            // the commond point of the four triangles
            gl.Vertex(0, 1.4, 0);

            // Base points of each triangle
            gl.Vertex(-1, 0, -1);
            gl.Vertex(-1, 0, 1);

            gl.Vertex(-1, 0, 1);
            gl.Vertex(1, 0, 1);

            gl.Vertex(1, 0, 1);
            gl.Vertex(1, 0, -1);

            gl.Vertex(1, 0, -1);
            gl.Vertex(-1, 0, -1);

            gl.End();

        }

    }
}
