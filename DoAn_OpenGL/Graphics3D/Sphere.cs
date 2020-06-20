using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class Sphere : Graphic3D
    {
        public Sphere(DrawStyle style, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Sphere";
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
            gl.PushMatrix();
            gl.Translate(LocationX, LocationY, LocationZ);
            gl.Rotate(RotateX, 1.0, 0.0, 0.0);
            gl.Rotate(RotateY, 0.0, 1.0, 0.0);
            gl.Rotate(RotateZ, 0.0, 0.0, 1.0);
            gl.Color(ColorR, ColorG, ColorB);
            SharpGL.SceneGraph.Quadrics.Sphere sphere = new SharpGL.SceneGraph.Quadrics.Sphere();
            sphere.Radius = SizeX;
            sphere.Slices = 100;
            sphere.Stacks = 100;
            sphere.QuadricDrawStyle = DrawStyle.Point;
            sphere.CreateInContext(gl);
            sphere.PushObjectSpace(gl);
            sphere.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            sphere.PopObjectSpace(gl);
            sphere.DestroyInContext(gl);
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
            SharpGL.SceneGraph.Quadrics.Sphere sphere = new SharpGL.SceneGraph.Quadrics.Sphere();
            sphere.Radius = SizeX;
            sphere.Slices = 100;
            sphere.Stacks = 100;
            sphere.QuadricDrawStyle = DrawStyle.Fill;
            sphere.CreateInContext(gl);
            sphere.PushObjectSpace(gl);
            sphere.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            sphere.PopObjectSpace(gl);
            sphere.DestroyInContext(gl);
            gl.PopMatrix();
        }


    }
}

