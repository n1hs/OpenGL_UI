using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public class FrustumShape : Graphic3D
    {
        public FrustumShape(DrawStyle style, double baseRadius, double topRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "FrustumShape";
            SizeX = baseRadius;
            SizeY = topRadius;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Slices = 4;
            Stacks = 50;
        }


        protected override void DrawPoint(OpenGL gl)
        {

            //SharpGL.SceneGraph.Quadrics.Cylinder frumstumShape = new SharpGL.SceneGraph.Quadrics.Cylinder();
            //frumstumShape.TopRadius = SizeY;
            //frumstumShape.BaseRadius = SizeX;
            //frumstumShape.Height = SizeZ;
            //frumstumShape.Slices = Slices;
            //frumstumShape.Stacks = Stacks;
            //frumstumShape.QuadricDrawStyle = DrawStyle.Point;

            //frumstumShape.CreateInContext(gl);
            //frumstumShape.PushObjectSpace(gl);
            //frumstumShape.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            //frumstumShape.PopObjectSpace(gl);
            //frumstumShape.DestroyInContext(gl);

            gl.PushMatrix();
            gl.Rotate(45, 0, 0, 1);
            gl.Begin(OpenGL.GL_POINTS);
            double stacks = Stacks;
            double tempX = SizeX * (System.Math.Sqrt(2)) / 2;
            double tempy = SizeY;
            //for (double i = -tempX; i <= tempX; i += 0.1)
            //{
            //    for (double j = -tempX; j <= tempX; j += 0.1)
            //    {
            //        gl.Vertex(i, j, 0);
            //    }
            //}
            //for (double i = -tempy; i <= tempy; i += 0.1)
            //{
            //    for (double j = -tempy; j <= tempy; j += 0.1)
            //    {
            //        gl.Vertex(i, j, SizeZ);
            //    }
            //}

            for (double j = 0; j<=SizeZ; j+=SizeZ/Stacks)
            {
                for(double i =-tempX; i<=tempX;i+=0.1)
                {
                    gl.Vertex(i, -tempX, j);
                }
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    gl.Vertex(i, tempX, j);
                }
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    gl.Vertex(-tempX, i, j);
                }
                for (double i = -tempX; i <= tempX; i += 0.1)
                {
                    gl.Vertex(tempX, i, j);
                }
                tempX -= ((SizeX - SizeY) / Stacks)*Math.Sqrt(2)/2;
            }
                //while (tempZ <= SizeZ)
                //{
                //    for (double i = -tempX; i <= tempX; i += 0.1)
                //    {
                //        for (double j = -tempX; j <= tempX; j += 0.1)
                //        {
                //            gl.Vertex(i, j, tempZ);
                //        }
                //    }
                //    tempX -= ((SizeX - SizeY) / stacks);
                //    tempZ += (SizeZ / stacks);
                //}

                gl.End();
                gl.PopMatrix();
        }
        protected override void DrawLine(OpenGL gl)
        {

            SharpGL.SceneGraph.Quadrics.Cylinder frumstumShape = new SharpGL.SceneGraph.Quadrics.Cylinder();
            frumstumShape.TopRadius = SizeY;
            frumstumShape.BaseRadius = SizeX;
            frumstumShape.Height = SizeZ;
            frumstumShape.Slices = Slices;
            frumstumShape.Stacks = Stacks;
            frumstumShape.QuadricDrawStyle = DrawStyle.Line;

            frumstumShape.CreateInContext(gl);
            frumstumShape.PushObjectSpace(gl);
            frumstumShape.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            frumstumShape.PopObjectSpace(gl);
            frumstumShape.DestroyInContext(gl);
        }
        
        protected override void DrawSolid(OpenGL gl)
        {
            var quadric = gl.NewQuadric();
            gl.QuadricDrawStyle(quadric, OpenGL.GL_FILL);
            gl.QuadricNormals(quadric, OpenGL.GLU_SMOOTH);
            gl.QuadricTexture(quadric, (int)OpenGL.GL_TRUE);
            gl.Cylinder(quadric, SizeX, 0, SizeZ, Slices, Stacks);
        }

    }
}
