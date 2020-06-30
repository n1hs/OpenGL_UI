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
            Name = "Cone";
            SizeX = baseRadius;
            SizeY = topRadius;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Slices = 100;
            Stacks = 100;
        }

        public TruncatedCone(DrawStyle style, double baseRadius, double topRadius,double height, int slices, int stacks, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Cone";
            SizeX = baseRadius;
            SizeY = topRadius;
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

            SharpGL.SceneGraph.Quadrics.Cylinder truncatedCone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            truncatedCone.TopRadius = SizeY;
            truncatedCone.BaseRadius = SizeX;
            truncatedCone.Height = SizeZ;
            truncatedCone.Slices = Slices;
            truncatedCone.Stacks = Stacks;
            truncatedCone.QuadricDrawStyle = DrawStyle.Fill;

            LightBegin(gl);

            truncatedCone.CreateInContext(gl);
            truncatedCone.PushObjectSpace(gl);
            truncatedCone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            truncatedCone.PopObjectSpace(gl);
            truncatedCone.DestroyInContext(gl);

            LightEnd(gl);

            gl.PopMatrix();

        }

    }
}
