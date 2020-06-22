using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class Teapot : Graphic3D
    {
        public Teapot(DrawStyle style, int grid, double size, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Teapot";
            SizeX = size;
            SizeY = size;
            SizeZ = size;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Slices = 0;
            Stacks = grid;
        }
        public override void DrawPoint(OpenGL gl)
        {
            gl.PushMatrix();
            Animation(gl);
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            gl.Translate(0.0, 0.0, SizeX - 0.25 * SizeX);
            gl.Rotate(90, 1.0, 0.0, 0.0);

            SharpGL.SceneGraph.Primitives.Teapot teapot = new SharpGL.SceneGraph.Primitives.Teapot();
            teapot.Draw(gl, Stacks, SizeX, OpenGL.GL_POINT);
            
            gl.PopMatrix();
        }
        public override void DrawLine(OpenGL gl)
        {
            gl.PushMatrix();
            Animation(gl);
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            gl.Translate(0.0, 0.0, SizeX - 0.25 * SizeX);
            gl.Rotate(90, 1.0, 0.0, 0.0);

            SharpGL.SceneGraph.Primitives.Teapot teapot = new SharpGL.SceneGraph.Primitives.Teapot();
            teapot.Draw(gl, Stacks, SizeX, OpenGL.GL_LINE);

            gl.PopMatrix();
        }
        
        public override void DrawSolid(OpenGL gl)
        {
            gl.PushMatrix();
            Animation(gl);
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            gl.Translate(0.0, 0.0, SizeX-0.25*SizeX);
            gl.Rotate(90, 1.0, 0.0, 0.0);

            SharpGL.SceneGraph.Primitives.Teapot teapot = new SharpGL.SceneGraph.Primitives.Teapot();
            teapot.Draw(gl, Stacks, SizeX, OpenGL.GL_FILL);

            gl.PopMatrix();
        }


    }
}
