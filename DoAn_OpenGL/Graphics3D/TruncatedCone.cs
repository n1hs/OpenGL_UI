using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.Windows.Media;

namespace DoAn_OpenGL.Graphics3D
{
    public class TruncatedCone : Graphic3D
    {
        public TruncatedCone(DrawStyle style, double baseRadius, double topRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "TruncatedCone";
            SizeX = baseRadius;
            SizeY = topRadius;
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

            SharpGL.SceneGraph.Quadrics.Cylinder truncatedCone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            truncatedCone.TopRadius = SizeY;
            truncatedCone.BaseRadius = SizeX;
            truncatedCone.Height = SizeZ;
            truncatedCone.Slices = Slices;
            truncatedCone.Stacks = Stacks;
            truncatedCone.QuadricDrawStyle = DrawStyle.Point;

            truncatedCone.CreateInContext(gl);
            truncatedCone.PushObjectSpace(gl);
            truncatedCone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            truncatedCone.PopObjectSpace(gl);
            truncatedCone.DestroyInContext(gl);
        }
        protected override void DrawLine(OpenGL gl)
        {

            SharpGL.SceneGraph.Quadrics.Cylinder truncatedCone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            truncatedCone.TopRadius = SizeY;
            truncatedCone.BaseRadius = SizeX;
            truncatedCone.Height = SizeZ;
            truncatedCone.Slices = Slices;
            truncatedCone.Stacks = Stacks;
            truncatedCone.QuadricDrawStyle = DrawStyle.Line;

            truncatedCone.CreateInContext(gl);
            truncatedCone.PushObjectSpace(gl);
            truncatedCone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            truncatedCone.PopObjectSpace(gl);
            truncatedCone.DestroyInContext(gl);
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
