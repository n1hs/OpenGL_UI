using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public class Pyramid : Graphic3D
    {
        public Pyramid(DrawStyle style, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Pyramid";
            SizeX = baseRadius;
            SizeY = 0;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Slices = 4;
            Stacks = 50;

        }


        protected override void DrawPoint(OpenGL gl)
        {

            SharpGL.SceneGraph.Quadrics.Cylinder pyramid = new SharpGL.SceneGraph.Quadrics.Cylinder();
            pyramid.TopRadius = SizeY;
            pyramid.BaseRadius = SizeX;
            pyramid.Height = SizeZ;
            pyramid.Slices = Slices;
            pyramid.Stacks = Stacks;
            pyramid.QuadricDrawStyle = DrawStyle.Point;

            pyramid.CreateInContext(gl);
            pyramid.PushObjectSpace(gl);
            pyramid.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            pyramid.PopObjectSpace(gl);
            pyramid.DestroyInContext(gl);

            //ve base radius by point
            gl.PushMatrix();
            gl.Rotate(45, 0, 0, 1);
            gl.Begin(OpenGL.GL_POINTS);
            double stacks = Stacks;
            double tempX = SizeX * (System.Math.Sqrt(2)) / 2;
            double tempy = SizeY;
            for (double j = 0; j <= SizeZ; j += SizeZ / Stacks)
            {
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    gl.Vertex(i, -tempX, j);
                }
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    gl.Vertex(i, tempX, j);
                }
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    gl.Vertex(-tempX, i, j);
                }
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    gl.Vertex(tempX, i, j);
                }
                tempX -= ((SizeX - SizeY) / Stacks) * Math.Sqrt(2) / 2;
            }
            gl.End();
            gl.PopMatrix();
        }
        protected override void DrawLine(OpenGL gl)
        {

            SharpGL.SceneGraph.Quadrics.Cylinder pyramid = new SharpGL.SceneGraph.Quadrics.Cylinder();
            pyramid.TopRadius = SizeY;
            pyramid.BaseRadius = SizeX;
            pyramid.Height = SizeZ;
            pyramid.Slices = Slices;
            pyramid.Stacks = Stacks;
            pyramid.QuadricDrawStyle = DrawStyle.Line;

            pyramid.CreateInContext(gl);
            pyramid.PushObjectSpace(gl);
            pyramid.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            pyramid.PopObjectSpace(gl);
            pyramid.DestroyInContext(gl);
        }
        
        protected override void DrawSolid(OpenGL gl)
        {
            var quadric = gl.NewQuadric();
            gl.QuadricDrawStyle(quadric, OpenGL.GL_FILL);
            gl.QuadricNormals(quadric, OpenGL.GLU_SMOOTH);
            gl.QuadricTexture(quadric, (int)OpenGL.GL_TRUE);
            gl.Cylinder(quadric, SizeX, SizeY, SizeZ, Slices, Stacks);
        }

    }
}
