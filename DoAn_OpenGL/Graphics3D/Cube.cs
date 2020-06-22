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
            SizeX = WidthX/2;
            SizeY = WidthY/2;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Stacks = 10;
        }

        public override void DrawPoint(OpenGL gl)
        {
            
            
            gl.PushMatrix();

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);


            gl.Begin(OpenGL.GL_POINTS);
            double tempX = SizeX;
            double tempY = SizeY;
            double tempZ = 0;
            while (tempZ <= SizeZ)
            {
                for (double i = -tempX; i <= tempX; i += SizeX/Stacks)
                {
                    for (double j = -tempY; j <= tempY; j += SizeY / Stacks)
                    {
                        gl.Vertex(i, j, tempZ);
                    }
                }
                tempZ += (SizeZ / Stacks);
            }
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

            gl.Begin(OpenGL.GL_LINES);
            double tempX = SizeX;
            double tempY = SizeY;
            double tempZ = 0;
            while (tempZ <= SizeZ)
            {
                for (double i = -tempX; i <= tempX; i += SizeX/Stacks)
                {
                    for (double j = -tempY; j <= tempY; j += SizeY/Stacks)
                    {
                        gl.Vertex(i, j, tempZ);
                        gl.Vertex(i, -j, tempZ);
                    }
                }
                tempZ += (SizeZ / Stacks);
            }
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            tempX = SizeX;
            tempY = SizeY;
            tempZ = 0;
            while (tempZ <= SizeZ)
            {
                for (double i = -tempX; i <= tempX; i += SizeX / Stacks)
                {
                    for (double j = -tempY; j <= tempY; j += SizeY / Stacks)
                    {
                        gl.Vertex(-i, j, tempZ);
                        gl.Vertex(i, j, tempZ);
                    }
                }
                tempZ += (SizeZ / Stacks);
            }
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
            gl.Vertex(-SizeX, SizeY, 0);
            gl.Vertex(-SizeX, SizeY, SizeZ);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(SizeX, SizeY, 0);
            gl.End();

            // left
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX, -SizeY, 0);
            gl.Vertex(-SizeX, -SizeY, SizeZ);
            gl.Vertex(-SizeX, SizeY, SizeZ);
            gl.Vertex(-SizeX, SizeY, 0);
            gl.End();

            //front
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX, -SizeY, 0);
            gl.Vertex(-SizeX, -SizeY, SizeZ);
            gl.Vertex(SizeX, -SizeY, SizeZ);
            gl.Vertex(SizeX, -SizeY, 0);
            gl.End();

            //// right
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(SizeX, SizeY, 0);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.Vertex(SizeX, -SizeY, SizeZ);
            gl.Vertex(SizeX, -SizeY, 0);
            gl.End();

            //Top
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX, SizeY, SizeZ);
            gl.Vertex(-SizeX, -SizeY, SizeZ);
            gl.Vertex(SizeX, -SizeY, SizeZ);
            gl.Vertex(SizeX, SizeY, SizeZ);
            gl.End();

            //Bottom
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX, SizeY, 0);
            gl.Vertex(-SizeX, -SizeY, 0);
            gl.Vertex(SizeX, -SizeY, 0);
            gl.Vertex(SizeX, SizeY, 0);
            gl.End();

            gl.PopMatrix();
        }


    }
}
