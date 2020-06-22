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
            SizeX = baseRadius/2;
            SizeY = 0;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Stacks = 100;

        }

        public override void DrawPoint(OpenGL gl)
        {
            gl.PushMatrix();

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            //ve 4 canh base
            double temp = 0;
            gl.Begin(OpenGL.GL_POINTS);

            temp = -SizeX;
            while (temp <= SizeX)
            {
                gl.Vertex(temp, -SizeX, 0);
                temp += 0.1;
            }

            temp = -SizeX;
            while (temp <= SizeX)
            {
                gl.Vertex(temp, SizeX, 0);
                temp += 0.1;
            }

            temp = -SizeX;
            while (temp <= SizeX)
            {
                gl.Vertex(-SizeX, temp, 0);
                temp += 0.1;
            }

            temp = -SizeX;
            while (temp <= SizeX)
            {
                gl.Vertex(SizeX, temp, 0);
                temp += 0.1;
            }

            gl.End();

            //ve 4 canh dinh
            gl.Begin(OpenGL.GL_POINTS);
            temp = 0;
            while(temp >= -1)
            {
                gl.Vertex(SizeX*temp,SizeX*temp,SizeZ*(1+temp));
                temp -= 0.01;
            }
            gl.End();

            gl.Begin(OpenGL.GL_POINTS);
            temp = 0;
            while (temp >= -1)
            {
                gl.Vertex(SizeX * temp, -SizeX * temp, SizeZ * (1 + temp));
                temp -= 0.01;
            }
            gl.End();

            gl.Begin(OpenGL.GL_POINTS);
            temp = 0;
            while (temp >= -1)
            {
                gl.Vertex(-SizeX * temp, SizeX * temp, SizeZ * (1 + temp));
                temp -= 0.01;
            }
            gl.End();

            gl.Begin(OpenGL.GL_POINTS);
            temp = 0;
            while (temp >= -1)
            {
                gl.Vertex(-SizeX * temp, -SizeX * temp, SizeZ * (1 + temp));
                temp -= 0.01;
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

           
            double tempX = SizeX;
            double tempZ = 0;
            gl.Begin(OpenGL.GL_LINES);

            while (tempZ <= SizeZ)
            {
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    for (double j = -tempX; j <= tempX; j += 0.1)
                    {
                        gl.Vertex(i, -j, tempZ);
                        gl.Vertex(i, j, tempZ);
                    }
                }
                tempX -= ((SizeX - SizeY) / Stacks);
                tempZ += (SizeZ / Stacks);
            }
            gl.End();

            tempX = SizeX;
            tempZ = 0;
            gl.Begin(OpenGL.GL_LINES);

            while (tempZ <= SizeZ)
            {
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    for (double j = -tempX; j <= tempX; j += 0.1)
                    {
                        gl.Vertex(-j, i, tempZ);
                        gl.Vertex(j, i, tempZ);
                    }
                }
                tempX -= ((SizeX - SizeY) / Stacks);
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

            // Draw the base square
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX, -SizeX, 0);
            gl.Vertex(-SizeX, SizeX, 0);
            gl.Vertex(SizeX, SizeX, 0);
            gl.Vertex(SizeX, -SizeX, 0);
            gl.End();

            // Draw four side triangles
            gl.Begin(OpenGL.GL_TRIANGLE_FAN);

            // the commond point of the four triangles
            gl.Vertex(0, 0, SizeZ);

            // Base points of each triangle
            gl.Vertex(-SizeX, -SizeX, 0);
            gl.Vertex(-SizeX, SizeX, 0);

            gl.Vertex(-SizeX, SizeX, 0);
            gl.Vertex(SizeX, SizeX, 0);

            gl.Vertex(SizeX, SizeX, 0);
            gl.Vertex(SizeX, -SizeX, 0);

            gl.Vertex(SizeX, -SizeX, 0);
            gl.Vertex(-SizeX, -SizeX, 0);

            gl.End();

            gl.PopMatrix();

        }

    }
}
