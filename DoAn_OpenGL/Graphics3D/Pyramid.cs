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
            gl.PushMatrix();

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            //ve size cua point
            gl.PointSize(3.0f);

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

            // Draw the base square
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(-SizeX, -SizeX, 0);
            gl.Vertex(-SizeX, SizeX, 0);

            gl.Vertex(-SizeX, SizeX, 0);
            gl.Vertex(SizeX, SizeX, 0);

            gl.Vertex(SizeX, SizeX, 0);
            gl.Vertex(SizeX, -SizeX, 0);

            gl.Vertex(SizeX, -SizeX, 0);
            gl.Vertex(-SizeX, -SizeX, 0);
            gl.End();

            // Draw four side triangles
            gl.Begin(OpenGL.GL_LINES);

            // the commond point of the four triangles
            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(-SizeX, -SizeX, 0);
            // Base points of each triangle

            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(-SizeX, SizeX, 0);

            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(SizeX, SizeX, 0);

            gl.Vertex(0, 0, SizeZ);
            gl.Vertex(SizeX, -SizeX, 0);

            

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
