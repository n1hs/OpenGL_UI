using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class Sphere : Graphic3D
    {
        public Sphere(DrawStyle style, double baseRadius, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Sphere";
            SizeX = baseRadius;
            SizeY = baseRadius;
            SizeZ = baseRadius;
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

            gl.Translate(0.0, 0.0, SizeX);

            SharpGL.SceneGraph.Quadrics.Sphere sphere = new SharpGL.SceneGraph.Quadrics.Sphere();
            sphere.Radius = SizeX;
            sphere.Slices = Slices;
            sphere.Stacks = Stacks;
            sphere.QuadricDrawStyle = DrawStyle.Point;

            sphere.CreateInContext(gl);
            sphere.PushObjectSpace(gl);
            sphere.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            sphere.PopObjectSpace(gl);
            sphere.DestroyInContext(gl);
        }
        protected override void DrawLine(OpenGL gl)
        {

            gl.Translate(0.0,0.0,SizeX);


            SharpGL.SceneGraph.Quadrics.Sphere sphere = new SharpGL.SceneGraph.Quadrics.Sphere();
            sphere.Radius = SizeX;
            sphere.Slices = 100;
            sphere.Stacks = 100;
            sphere.QuadricDrawStyle = DrawStyle.Line;

            sphere.CreateInContext(gl);
            sphere.PushObjectSpace(gl);
            sphere.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            sphere.PopObjectSpace(gl);
            sphere.DestroyInContext(gl);
        }

        protected override void DrawSolid(OpenGL gl)
        {

            gl.Translate(0.0, 0.0, SizeX);

            var quadric = gl.NewQuadric();
            gl.QuadricDrawStyle(quadric, OpenGL.GL_FILL);
            gl.QuadricNormals(quadric, OpenGL.GLU_SMOOTH);
            gl.QuadricTexture(quadric, (int)OpenGL.GL_TRUE);
            gl.Sphere(quadric, SizeX,  Slices, Stacks);
        }


    }
}

