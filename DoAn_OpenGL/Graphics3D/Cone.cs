using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public class Cone : Graphic3D
    {
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public double LocationZ { get; private set; }

        public double SizeX { get; private set; }
        public double SizeY { get; private set; }
        public double SizeZ { get; private set; }

        public double ColorR { get; private set; }
        public double ColorG { get; private set; }
        public double ColorB { get; private set; }

        public double RotateX { get; private set; }
        public double RotateY { get; private set; }
        public double RotateZ { get; private set; }

        public string Name { get; private set; }

        public DrawStyle Style { get; private set; }
        public Cone(double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0) 
        {
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
        public void DrawPoint(OpenGL gl)
        {
        }
        public void DrawLine(OpenGL gl)
        {
        }
        //ham ve hinh non
        public void DrawSolid(OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0,0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);
            Cylinder cone = new Cylinder();
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


        public static Cone DrawConeSolid(OpenGL gl, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0)
        {
            gl.PushMatrix();
            gl.Translate(tranX, tranY, 0);
            gl.Color(R, G, B);
            Cylinder cone = new Cylinder();
            cone.TopRadius = 0;
            cone.BaseRadius = baseRadius;
            cone.Height = height;
            cone.Slices = 100;
            cone.Stacks = 100;

            cone.CreateInContext(gl);
            cone.PushObjectSpace(gl);
            cone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cone.PopObjectSpace(gl);
            cone.DestroyInContext(gl);
            gl.PopMatrix();
            return new Cone(baseRadius, height, R, G, B, tranX, tranY);
        }

    }
}
