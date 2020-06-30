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
            Stacks = 10;

        }

        public Pyramid(DrawStyle style, double baseRadius, double height, int stacks, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
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
            Stacks = stacks;

        }

        public override void DrawPoint(OpenGL gl)
        {
            gl.PushMatrix();
            Animation(gl);
            //ham chieu sang -> toan phan, ,do bong(gl)

            //them enum trong Graphics3D

            //them ham chieu sang

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

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

            SharpGL.SceneGraph.Quadrics.Cylinder pyramid = new SharpGL.SceneGraph.Quadrics.Cylinder();
            pyramid.TopRadius = SizeY;
            pyramid.BaseRadius = SizeX;
            pyramid.Height = SizeZ;
            pyramid.Slices = Slices;
            pyramid.Stacks = Stacks;
            pyramid.QuadricDrawStyle = DrawStyle.Fill;

            LightBegin(gl);

            pyramid.CreateInContext(gl);
            pyramid.PushObjectSpace(gl);
            pyramid.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            pyramid.PopObjectSpace(gl);
            pyramid.DestroyInContext(gl);

            LightEnd(gl);

            gl.PopMatrix();
        }

    }
}
