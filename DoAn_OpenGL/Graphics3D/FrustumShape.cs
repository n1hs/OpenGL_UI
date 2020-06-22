using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public class FrustumShape : Graphic3D
    {
        public FrustumShape(DrawStyle style, double baseRadius, double topRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "FrustumShape";
            SizeX = baseRadius/2;
            SizeY = topRadius/2;
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

            gl.Begin(OpenGL.GL_POINTS);
            double stacks = 10;
            double tempX = SizeX;
            double tempZ = 0;
            while (tempZ <= SizeZ)
            {
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    for (double j = -tempX; j <= tempX; j += 0.1)
                    {
                        gl.Vertex(i, j, tempZ);
                    }
                }
                tempX -= ((SizeX - SizeY) / stacks);
                tempZ += (SizeZ / stacks);
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

            // Draw the base
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX, -SizeX, 0);
            gl.Vertex(-SizeX, SizeX, 0);
            gl.Vertex(SizeX, SizeX, 0);
            gl.Vertex(SizeX, -SizeX, 0);
            gl.End();

            // Draw 4 side
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeX, -SizeX, 0);
            gl.Vertex(SizeX, -SizeX, 0);
            gl.Vertex(SizeY,-SizeY,SizeZ);
            gl.Vertex(-SizeY, -SizeY, SizeZ);

            gl.Vertex(SizeX, -SizeX, 0);
            gl.Vertex(SizeY, -SizeY, SizeZ);
            gl.Vertex(SizeY, SizeY, SizeZ);
            gl.Vertex(SizeX, SizeX, 0);

            gl.Vertex(SizeY, SizeY, SizeZ);
            gl.Vertex(SizeX, SizeX, 0);
            gl.Vertex(-SizeX, SizeX, 0);
            gl.Vertex(-SizeY, SizeY, SizeZ);

            gl.Vertex(-SizeX, SizeX, 0);
            gl.Vertex(-SizeY, SizeY, SizeZ);
            gl.Vertex(-SizeY, -SizeY, SizeZ);
            gl.Vertex(-SizeX, -SizeX, 0);
            gl.End();

            // Draw top base
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-SizeY, -SizeY, SizeZ);
            gl.Vertex(-SizeY, SizeY, SizeZ);
            gl.Vertex(SizeY, SizeY, SizeZ);
            gl.Vertex(SizeY, -SizeY, SizeZ);
            gl.End();

            gl.PopMatrix();
        }

    }
}
