using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.Windows.Controls;

namespace DoAn_OpenGL.Graphics3D
{
    public class Cylinder : Graphic3D
    {
        public Cylinder(DrawStyle style, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Cylinder";
            SizeX = baseRadius;
            SizeY = baseRadius;
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

        public Cylinder(DrawStyle style, double baseRadius, double height, int slices, int stacks, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Cylinder";
            SizeX = baseRadius;
            SizeY = baseRadius;
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

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            SharpGL.SceneGraph.Quadrics.Cylinder cylinder = new SharpGL.SceneGraph.Quadrics.Cylinder();
            cylinder.TopRadius = SizeY;
            cylinder.BaseRadius = SizeX;
            cylinder.Height = SizeZ;
            cylinder.Slices = Slices;
            cylinder.Stacks = Stacks;
            cylinder.QuadricDrawStyle = DrawStyle.Point;

            cylinder.CreateInContext(gl);
            cylinder.PushObjectSpace(gl);
            cylinder.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cylinder.PopObjectSpace(gl);
            cylinder.DestroyInContext(gl);

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

            SharpGL.SceneGraph.Quadrics.Cylinder cylinder = new SharpGL.SceneGraph.Quadrics.Cylinder();
            cylinder.TopRadius = SizeY;
            cylinder.BaseRadius = SizeX;
            cylinder.Height = SizeZ;
            cylinder.Slices = Slices;
            cylinder.Stacks = Stacks;
            cylinder.QuadricDrawStyle = DrawStyle.Line;

            cylinder.CreateInContext(gl);
            cylinder.PushObjectSpace(gl);
            cylinder.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cylinder.PopObjectSpace(gl);
            cylinder.DestroyInContext(gl);

            gl.PopMatrix();
        }
        public override void DrawSolid(OpenGL gl)
        {
            //gl.PushMatrix();

            //gl.Translate(LocationX, LocationY, LocationZ);
            //gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            //gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            //gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            //gl.Color(ColorR, ColorG, ColorB);

            //gl.Begin(OpenGL.GL_POLYGON);
            //for (int iogl = 0; iogl <= 359; iogl++)
            //{
            //    gl.Vertex(SizeX * (double) Math.Sin(Math.PI / 180 * iogl), SizeX * (double)Math.Cos(Math.PI / 180 * iogl), 0);
            //    gl.Vertex(SizeX * (double)Math.Sin(Math.PI / 180 * (iogl + 30)), SizeX * (double)Math.Cos(Math.PI / 180 * (iogl + 30)), 0);

            //    gl.Vertex(SizeX * (double)Math.Sin(Math.PI / 180 * iogl), SizeX * (double)Math.Cos(Math.PI / 180 * iogl), SizeZ);
            //    gl.Vertex(SizeX * (double)Math.Sin(Math.PI / 180 * (iogl + 30)), SizeX * (double)Math.Cos(Math.PI / 180 * (iogl + 30)), SizeZ);
            //}
            //gl.End();

            //gl.PopMatrix();

            gl.PushMatrix();

            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            SharpGL.SceneGraph.Quadrics.Cylinder cylinder = new SharpGL.SceneGraph.Quadrics.Cylinder();

            cylinder.QuadricDrawStyle = DrawStyle.Fill;

            cylinder.TopRadius = SizeY;
            cylinder.BaseRadius = SizeX;
            cylinder.Height = SizeZ;
            cylinder.Slices = Slices;
            cylinder.Stacks = Stacks;

            cylinder.CreateInContext(gl);
            cylinder.PushObjectSpace(gl);
            cylinder.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cylinder.PopObjectSpace(gl);
            cylinder.DestroyInContext(gl);

            gl.PopMatrix();
        }

    }
}
