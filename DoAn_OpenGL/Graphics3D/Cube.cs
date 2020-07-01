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
            Slices = 15;
            Stacks = 15;
        }


        protected override void DrawPoint(OpenGL gl)
        {

            gl.Begin(OpenGL.GL_POINTS);
            double tempX = SizeX/2;
            double tempY = SizeY/2;
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

        }

        protected override void DrawLine(OpenGL gl)
        {
            //draw columns
            gl.Begin(OpenGL.GL_LINES);
            double tempX = SizeX/2;
            double tempY = SizeY/2;
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

            //draw row
            gl.Begin(OpenGL.GL_LINES);
            tempX = SizeX/2;
            tempY = SizeY/2;
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

            //draw 4 side columns
            gl.Begin(OpenGL.GL_LINES);
            tempX = SizeX / 2;
            tempY = SizeY / 2;
            for(double i = -tempX; i<tempX; i += SizeX / Stacks)
            {
                gl.Vertex(i,-tempY,0);
                gl.Vertex(i,-tempY, SizeZ);
            }
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            tempX = SizeX / 2;
            tempY = SizeY / 2;
            for (double i = -tempY; i < tempY; i += SizeY / Stacks)
            {
                gl.Vertex(tempX, i, 0);
                gl.Vertex(tempX, i, SizeZ);
            }
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            tempX = SizeX / 2;
            tempY = SizeY / 2;
            for (double i = tempX; i > -tempX; i -= SizeX / Stacks)
            {
                gl.Vertex(i, tempY, 0);
                gl.Vertex(i, tempY, SizeZ);
            }
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            tempX = SizeX / 2;
            tempY = SizeY / 2;
            for (double i = tempY; i > -tempY; i -= SizeY / Stacks)
            {
                gl.Vertex(-tempX, i, 0);
                gl.Vertex(-tempX, i, SizeZ);
            }
            gl.End();

        }
        
        protected override void DrawSolid(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-SizeX / 2, -SizeY / 2, SizeZ); // Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(SizeX / 2, -SizeY / 2, SizeZ);  // Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(SizeX / 2, SizeY / 2, SizeZ);   // Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-SizeX / 2, SizeY / 2, SizeZ);  // Top Left Of The Texture and Quad

            // Back Face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-SizeX / 2, -SizeY / 2, 0);    // Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-SizeX / 2, SizeY / 2, 0); // Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(SizeX / 2, SizeY / 2, 0);  // Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(SizeX / 2, -SizeY / 2, 0); // Bottom Left Of The Texture and Quad

            // Top Face
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-SizeX / 2, SizeY / 2, 0); // Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-SizeX / 2, SizeY / 2, SizeZ);  // Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(SizeX / 2, SizeY / 2, SizeZ);   // Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(SizeX / 2, SizeY / 2, 0);  // Top Right Of The Texture and Quad

            // Bottom Face
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-SizeX / 2, -SizeY / 2, 0);    // Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(SizeX / 2, -SizeY / 2, 0); // Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(SizeX / 2, -SizeY / 2, SizeZ);  // Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-SizeX / 2, -SizeY / 2, SizeZ); // Bottom Right Of The Texture and Quad

            // Right face
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(SizeX / 2, -SizeY / 2, 0); // Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(SizeX / 2, SizeY / 2, 0);  // Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(SizeX / 2, SizeY / 2, SizeZ);   // Top Left Of The Texture and Quad
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(SizeX / 2, -SizeY / 2, SizeZ);  // Bottom Left Of The Texture and Quad

            // Left Face
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-SizeX / 2, -SizeY / 2, 0);    // Bottom Left Of The Texture and Quad
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(-SizeX / 2, -SizeY / 2, SizeZ); // Bottom Right Of The Texture and Quad
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(-SizeX / 2, SizeY / 2, SizeZ);  // Top Right Of The Texture and Quad
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-SizeX / 2, SizeY / 2, 0);	// Top Left Of The Texture and Quad
            gl.End();

        }


    }
}
