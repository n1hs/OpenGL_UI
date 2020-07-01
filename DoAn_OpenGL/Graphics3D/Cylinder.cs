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
            Slices = 50;
            Stacks = 50;
        }


        protected override void DrawPoint(OpenGL gl)
        {

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
        }
        protected override void DrawLine(OpenGL gl)
        {

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
