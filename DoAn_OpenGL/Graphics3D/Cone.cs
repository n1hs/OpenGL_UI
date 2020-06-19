﻿using SharpGL;
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
        }
        public override void DrawLine(OpenGL gl)
        {
        }
        //ham ve hinh non
        public override void DrawSolid(OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0,0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);
            SharpGL.SceneGraph.Quadrics.Cylinder cone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            cone.TopRadius = 0;
            cone.BaseRadius = SizeX;
            cone.Height = SizeZ;
            cone.Slices = 100;
            cone.Stacks = 100;

            cone.CreateInContext(gl);
            cone.PushObjectSpace(gl);
            cone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cone.PopObjectSpace(gl);
            cone.DestroyInContext(gl);
            gl.PopMatrix();
        }

        public static Cone DrawConePoint(OpenGL gl, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0)
        {
            return null;
        }
        public static Cone DrawConeLine(OpenGL gl, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0)
        {
            return null;
        }


    }
}
