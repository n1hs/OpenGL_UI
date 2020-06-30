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
            Slices = 10;
            Stacks = 10;
        }

        public Cube(DrawStyle style, double WidthX, double WidthY, double height, int slices, int stacks, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
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
            Slices = slices;
            Stacks = stacks;
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

            LightBegin(gl);
            //Back
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX/2, SizeY/2, 0);
            gl.Vertex(-SizeX/2, SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, SizeY/2, 0);
            gl.End();

            // left
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX/2, -SizeY/2, 0);
            gl.Vertex(-SizeX/2, -SizeY/2, SizeZ);
            gl.Vertex(-SizeX/2, SizeY/2, SizeZ);
            gl.Vertex(-SizeX/2, SizeY/2, 0);
            gl.End();

            //front
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX/2, -SizeY/2, 0);
            gl.Vertex(-SizeX/2, -SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, -SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, -SizeY/2, 0);
            gl.End();

            //// right
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(SizeX/2, SizeY/2, 0);
            gl.Vertex(SizeX/2, SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, -SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, -SizeY/2, 0);
            gl.End();

            //Top
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX/2, SizeY/2, SizeZ);
            gl.Vertex(-SizeX/2, -SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, -SizeY/2, SizeZ);
            gl.Vertex(SizeX/2, SizeY/2, SizeZ);
            gl.End();

            //Bottom
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX/2, SizeY/2, 0);
            gl.Vertex(-SizeX/2, -SizeY/2, 0);
            gl.Vertex(SizeX/2, -SizeY/2, 0);
            gl.Vertex(SizeX/2, SizeY/2, 0);
            gl.End();

            LightEnd(gl);

            gl.PopMatrix();
        }


    }
}
