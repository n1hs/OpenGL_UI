using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using DoAn_OpenGL.Assets;
using System;
using System.Drawing;

namespace DoAn_OpenGL.Graphics3D
{
    public abstract class Graphic3D 
    {
        private double templx;
        private double temply;
        private double temprx;
        private double tempry;
        private double temprz;
        private Translational animationTT;
        protected bool ambientFlag;
        public bool IsSelected { get; set; }
        public Translational AnimationTT
        {
            get { return animationTT; }
            set { 
                if(animationTT == Translational.None && value != Translational.None)
                {
                    templx = LocationX;
                    temply = LocationY;
                }
                if (animationTT !=  value )
                {
                    LocationX = templx;
                    LocationY = temply;
                }
                animationTT = value;                
            }
        }

        private Rotatory animationXoay;

        public Rotatory AnimationXoay
        {
            get { return animationXoay; }
            set {
                if (animationXoay == Rotatory.None && value != Rotatory.None)
                {
                    temprx = RotateX;
                    tempry = RotateY;
                    temprz = RotateZ;
                }
                if (animationXoay != value)
                {
                    RotateX = temprx;
                    RotateY = tempry;
                    RotateZ = temprz;
                }
                animationXoay = value; 
            }
        }

        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double LocationZ { get; set; }

        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }

        public int Slices { get; set; }
        public int Stacks { get; set; }

        public double ColorR { get; set; }
        public double ColorG { get; set; }
        public double ColorB { get; set; }

        public double RotateX { get; set; }
        public double RotateY { get; set; }
        public double RotateZ { get; set; }

        public string Name { get; set; }

        public DrawStyle Style { get; protected set; }
        public Point LightSource { get; set; }

        public Lighting LightingMode { get; set; } 
        public abstract void DrawPoint(OpenGL gl);
        public abstract void DrawLine(OpenGL gl);
        public abstract void DrawSolid(OpenGL gl);


        protected void Animation(OpenGL gl)
        {
           switch(AnimationTT)
            {
                case Translational.Ox:
                    LocationX +=0.3;
                    if (LocationX > 10)
                        LocationX = -10;
                    break;
                case Translational.Oy:
                    LocationY+=0.3;
                    if (LocationY > 10)
                        LocationY = -10;
                    break;
            }
            switch (AnimationXoay)
            {
                case Assets.Rotatory.Ox:
                    RotateX+=5;
                    break;
                case Assets.Rotatory.Oy:
                    RotateY += 5 ;
                    break;
                case Assets.Rotatory.Oz:
                    RotateZ += 5 ;
                    break;
            }
        }

        protected void LightBegin(OpenGL gl)
        {
            switch(LightingMode)
            {
                case Lighting.AMBIENT:
                    gl.Enable(OpenGL.GL_LIGHTING);
                    gl.Enable(OpenGL.GL_LIGHT0);
                    float[] light_pos = new float[4];
                    light_pos[0] = (float)0.0;
                    light_pos[1] = (float)0.0;
                    light_pos[2] = (float)0.0;
                    light_pos[3] = (float)0.0;
                    gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, light_pos);
                    break;
                case Lighting.DIFFUSE:

                    ///Code chiếu sáng
                    ///
                    break;
                case Lighting.SHADOW:

                    ///Code đổ bóng
                    ///
                    break;
                default: break;
            }    
        }
        protected void LightEnd(OpenGL gl)
        {
            switch (LightingMode)
            {
                case Lighting.AMBIENT:
                    gl.Disable(OpenGL.GL_LIGHTING);
                    break;
                case Lighting.DIFFUSE:

                    ///Code chiếu sáng
                    ///
                    break;
                case Lighting.SHADOW:

                    ///Code đổ bóng
                    ///
                    break;
                default: break;
            }
        }

        protected void DrawBoder(OpenGL gl, double x, double y, double z, int mode = 0)
        {
            if (!IsSelected)
                return;
            double tempzs = 0;
            if(mode == 1)
            {
                tempzs = -z;
            }
            if (mode == 2)
            {
                gl.PushMatrix();
                gl.Translate(0,0, -z);
                z = 2 * z;
            }
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0.8, 1, 1);
            gl.Vertex(-x - 0.12, y + 0.12, tempzs);
            gl.Vertex(x + 0.12, y + 0.12, tempzs);

            gl.Vertex(x + 0.12, y + 0.12, tempzs);
            gl.Vertex(x + 0.12, -y - 0.12, tempzs);

            gl.Vertex(x + 0.12, -y - 0.12, tempzs);
            gl.Vertex(-x - 0.12, -y - 0.12, tempzs);

            gl.Vertex(-x - 0.12, -y - 0.12, tempzs);
            gl.Vertex(-x - 0.12, y + 0.12, tempzs);

            gl.Vertex(-x - 0.12, y + 0.12, z);
            gl.Vertex(x + 0.12, y + 0.12, z);

            gl.Vertex(x + 0.12, y + 0.12, z);
            gl.Vertex(x + 0.12, -y - 0.12, z);

            gl.Vertex(x + 0.12, -y - 0.12, z);
            gl.Vertex(-x - 0.12, -y - 0.12, z);

            gl.Vertex(-x - 0.12, -y - 0.12, z);
            gl.Vertex(-x - 0.12, y + 0.12, z);

            gl.Vertex(-x - 0.12, y + 0.12, z);
            gl.Vertex(-x - 0.12, y + 0.12, tempzs);

            gl.Vertex(x + 0.12, y + 0.12, z);
            gl.Vertex(x + 0.12, y + 0.12, tempzs);

            gl.Vertex(x + 0.12, -y - 0.12, z);
            gl.Vertex(x + 0.12, -y - 0.12, tempzs);

            gl.Vertex(-x - 0.12, -y - 0.12, z);
            gl.Vertex(-x - 0.12, -y - 0.12, tempzs);
            gl.End();
            if (mode == 2)
            {
                gl.PopMatrix();
            }
        }

        public Graphic3D()
        {
            LightingMode = Lighting.NONE;

        }
    }
}
