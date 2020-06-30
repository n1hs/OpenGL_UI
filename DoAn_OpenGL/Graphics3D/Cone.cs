using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Lighting;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.ComponentModel;
using System.Configuration;

namespace DoAn_OpenGL.Graphics3D
{
    public class Cone : Graphic3D
    {
        
        public Cone(DrawStyle style,double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0) : base()
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
            Slices = Stacks = 50;
            ambientFlag = true;
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

            DrawBoder(gl, SizeX, SizeX, SizeZ);
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

            DrawBoder(gl, SizeX, SizeX, SizeZ);
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

            SharpGL.SceneGraph.Quadrics.Cylinder cone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            cone.TopRadius = SizeY;
            cone.BaseRadius = SizeX;
            cone.Height = SizeZ;
            cone.Slices = Slices;
            cone.Stacks = Stacks;
            cone.QuadricDrawStyle = DrawStyle.Fill;

            LightBegin(gl);

            cone.CreateInContext(gl);
            cone.PushObjectSpace(gl);
            cone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cone.PopObjectSpace(gl);
            cone.DestroyInContext(gl);

            LightEnd(gl);

            DrawBoder(gl,SizeX, SizeX, SizeZ);

            gl.PopMatrix();
        }

        

    }
}
