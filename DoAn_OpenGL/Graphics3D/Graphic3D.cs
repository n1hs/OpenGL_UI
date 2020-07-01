using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using DoAn_OpenGL.Assets;
using System;
using System.Drawing;
using System.Data;
using System.Windows.Controls.Primitives;
using System.Drawing.Imaging;

namespace DoAn_OpenGL.Graphics3D
{
    public abstract class Graphic3D 
    {
        private double templx;
        private double temply;
        private double temprx;
        private double tempry;
        private double temprz;
        private BitmapData bitmapData;
        public Bitmap Texture { get; set; }
        private Translational animationTT;
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
        public double LightSourceX { get; set; }
        public double LightSourceY { get; set; }
        public double LightSourceZ { get; set; }

        public Lighting LightingMode { get; set; } 
        public void Draw(OpenGL gl)
        {
            Init(gl);
            if (Style == DrawStyle.Fill)
                DrawSolid(gl);
            if (Style == DrawStyle.Point)
                DrawPoint(gl);
            if (Style == DrawStyle.Line)
                DrawLine(gl);
            EndInit(gl);
        }
        protected abstract void DrawPoint(OpenGL gl);
        protected abstract void DrawLine(OpenGL gl);
        protected abstract void DrawSolid(OpenGL gl);


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

        protected void Init(OpenGL gl)
        {
            gl.PushMatrix();
            Animation(gl);
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);

            if (Style != DrawStyle.Fill)
                return;

            ////Lighting
            switch (LightingMode)
            {
                case Lighting.AMBIENT:
                    gl.Enable(OpenGL.GL_LIGHTING);
                    gl.Enable(OpenGL.GL_LIGHT0);
                    float[] ambient = new float[4];
                    ambient[0] = (float)0.0;
                    ambient[1] = (float)0.0;
                    ambient[2] = (float)0.0;
                    ambient[3] = (float)1.0;
                    gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, ambient);
                    break;
                case Lighting.POSITION:
                    gl.Enable(OpenGL.GL_LIGHTING);
                    gl.Enable(OpenGL.GL_LIGHT0);
                    float[] light_pos = new float[4];
                    light_pos[0] = (float)LightSourceX;
                    light_pos[1] = (float)LightSourceY;
                    light_pos[2] = (float)LightSourceZ;
                    light_pos[3] = (float)0.0;
                    gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_pos);
                    ///Code chiếu sáng
                    ///
                    break;
                case Lighting.SHADOW:

                    ///Code đổ bóng
                    ///
                    break;
                default: break;
            }

            ///
            ///Texture
            ///
            if (Texture != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                uint[] textures = new uint[1];
                gl.GenTextures(1, textures);

                gl.BindTexture(OpenGL.GL_TEXTURE_2D, textures[0]);
                bitmapData = Texture.LockBits(new Rectangle(0, 0, Texture.Width, Texture.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, 3, Texture.Width, Texture.Height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
                    bitmapData.Scan0);
                //  Specify linear filtering.
                gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
                gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
            }
        }
        protected void EndInit(OpenGL gl)
        {
            if (Style == DrawStyle.Fill)
            {

                switch (LightingMode)
                {
                    case Lighting.AMBIENT:
                        gl.Disable(OpenGL.GL_LIGHT0);
                        gl.Disable(OpenGL.GL_LIGHTING);
                        break;
                    case Lighting.POSITION:
                        gl.Disable(OpenGL.GL_LIGHT0);
                        gl.Disable(OpenGL.GL_LIGHTING);
                        ///Code chiếu sáng
                        ///
                        break;
                    case Lighting.SHADOW:

                        ///Code đổ bóng
                        ///
                        break;
                    default: break;
                }

                if (Texture != null)
                {
                    Texture.UnlockBits(bitmapData);
                    gl.BindTexture(OpenGL.GL_TEXTURE_2D, 0);
                    gl.Disable(OpenGL.GL_TEXTURE_2D);
                }
            }

            DrawBoder(gl, SizeX, SizeX, SizeZ);
            gl.PopMatrix();
        }

        protected void DrawBoder(OpenGL gl, double x, double y, double z)
        {
            if (!IsSelected)
                return;
            double tempzs = 0;
            if (this is Cube)
            {
                x = x / 2;
                y = y / 2;
            }
            if (this is Sphere)
            {
                tempzs = -z;
            }
            if (this is Teapot)
            {
                gl.PushMatrix();
                gl.Translate(0,0, -x);
                z = 2 * x;
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
            if (this is Teapot)
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
