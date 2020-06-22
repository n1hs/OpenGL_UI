using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public abstract class Graphic3D 
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double LocationZ { get; set; }

        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }

        public int Stacks { get; set; }

        public double ColorR { get; set; }
        public double ColorG { get; set; }
        public double ColorB { get; set; }

        public double RotateX { get; set; }
        public double RotateY { get; set; }
        public double RotateZ { get; set; }

        public string Name { get; set; }

        public DrawStyle Style { get; protected set; }

        public abstract void DrawPoint(OpenGL gl);
        public abstract void DrawLine(OpenGL gl);
        public abstract void DrawSolid(OpenGL gl);
    }
}
