using SharpGL;
using SharpGL.SceneGraph;
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
            
            gl.PushMatrix();

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);
            //Back
            gl.Begin(OpenGL.GL_POINT_SIZE_MAX_ARB);
            gl.Normal(0.0f, 0.0f, -1.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(0, SizeY, 0);
            gl.End();

            // left
            gl.Begin(OpenGL.GL_POINTS);
            gl.Normal(-1.0f, 0.0f, 0.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.Vertex(0, SizeY, 0);
            gl.End();

            //front
            gl.Begin(OpenGL.GL_POINTS);
            gl.Normal(0.0f, 0.0f, 1.0f);
            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.End();

            //// right
            gl.Begin(OpenGL.GL_POINTS);
            gl.Normal(1.0f, 0.0f, 0.0f);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.End();

            //Top
            gl.Begin(OpenGL.GL_POINTS);
            gl.Normal(0.0f, 1.0f, 0.0f);
            gl.Vertex(0, SizeY, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.End();

            //Bottom
            gl.Begin(OpenGL.GL_POINTS);
            gl.Normal(0.0f, -1.0f, 0.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.Vertex(0, 0, SizeZ);
            gl.End();

            gl.PopMatrix();

        }

        public override void DrawLine(OpenGL gl)
        {
            
            gl.PushMatrix();

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);
            //Back
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Normal(0.0f, 0.0f, -1.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(0, SizeY, 0);
            gl.End();

            // left
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Normal(-1.0f, 0.0f, 0.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.Vertex(0, SizeY, 0);
            gl.End();

            //front
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Normal(0.0f, 0.0f, 1.0f);
            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.End();

            //// right
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Normal(1.0f, 0.0f, 0.0f);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.End();

            //Top
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Normal(0.0f, 1.0f, 0.0f);
            gl.Vertex(0, SizeY, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.End();

            //Bottom
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Normal(0.0f, -1.0f, 0.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.Vertex(0, 0, SizeZ);
            gl.End();

            gl.PopMatrix();
        }
        
        public override void DrawSolid(OpenGL gl)
        {
            
            gl.PushMatrix();
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);
            //Back
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, 0.0f, -1.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(0, SizeY, 0);
            gl.End();

            // left
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(-1.0f, 0.0f, 0.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.Vertex(0, SizeY, 0);
            gl.End();

            //front
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, 0.0f, 1.0f);
            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.End();

            //// right
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(1.0f, 0.0f, 0.0f);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.End();

            //Top
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, 1.0f, 0.0f);
            gl.Vertex(0, SizeY, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(0, SizeY, SizeZ);
            gl.End();

            //Bottom
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, -1.0f, 0.0f);
            gl.Vertex(0, 0, 0);
            gl.Vertex(SizeX, 0, 0);
            gl.Vertex(SizeX, 0, SizeZ);
            gl.Vertex(0, 0, SizeZ);
            gl.End();

            gl.PopMatrix();
            

           

        }


    }
}
