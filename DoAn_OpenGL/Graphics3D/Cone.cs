using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public class Cone : Graphic3D
    {
        
        public Cone(DrawStyle style,double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0) 
        {
            Style = style;
            Name = "Cone";
            SizeX = baseRadius;
            SizeY = 0;
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

        public Cone(DrawStyle style, double baseRadius, double height, int slices, int stacks, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Cone";
            SizeX = baseRadius;
            SizeY = 0;
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

            SharpGL.SceneGraph.Quadrics.Cylinder cone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            cone.TopRadius = SizeY;
            cone.BaseRadius = SizeX;
            cone.Height = SizeZ;
            cone.Slices = Slices;
            cone.Stacks = Stacks;
            cone.QuadricDrawStyle = DrawStyle.Point;

            cone.CreateInContext(gl);
            cone.PushObjectSpace(gl);
            cone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cone.PopObjectSpace(gl);
            cone.DestroyInContext(gl);

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

            SharpGL.SceneGraph.Quadrics.Cylinder cone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            cone.TopRadius = SizeY;
            cone.BaseRadius = SizeX;
            cone.Height = SizeZ;
            cone.Slices = Slices;
            cone.Stacks = Stacks;
            cone.QuadricDrawStyle = DrawStyle.Line;

            cone.CreateInContext(gl);
            cone.PushObjectSpace(gl);
            cone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cone.PopObjectSpace(gl);
            cone.DestroyInContext(gl);

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

            SharpGL.SceneGraph.Quadrics.Cylinder cone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            cone.TopRadius = SizeY;
            cone.BaseRadius = SizeX;
            cone.Height = SizeZ;
            cone.Slices = Slices;
            cone.Stacks = Stacks;
            cone.QuadricDrawStyle = DrawStyle.Fill;

            cone.CreateInContext(gl);
            cone.PushObjectSpace(gl);
            cone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cone.PopObjectSpace(gl);
            cone.DestroyInContext(gl);

            gl.PopMatrix();
        }
    }
}
