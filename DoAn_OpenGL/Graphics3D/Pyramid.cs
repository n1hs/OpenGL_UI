using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class Pyramid : Graphic3D
    {
        public Pyramid(DrawStyle style, double baseRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Pyramid";
            SizeX = baseRadius;
            SizeY = 0;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Slices = 4;
            Stacks = 100;

        }

        public Pyramid(DrawStyle style, double baseRadius, double height, int stacks, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Pyramid";
            SizeX = baseRadius;
            SizeY = 0;
            SizeZ = height;
            ColorR = R;
            ColorG = G;
            ColorB = B;
            LocationX = tranX;
            LocationY = tranY;
            LocationZ = tranZ;
            Slices = 4;
            Stacks = stacks;

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

            SharpGL.SceneGraph.Quadrics.Cylinder pyramid = new SharpGL.SceneGraph.Quadrics.Cylinder();
            pyramid.TopRadius = SizeY;
            pyramid.BaseRadius = SizeX;
            pyramid.Height = SizeZ;
            pyramid.Slices = Slices;
            pyramid.Stacks = Stacks;
            pyramid.QuadricDrawStyle = DrawStyle.Point;

            pyramid.CreateInContext(gl);
            pyramid.PushObjectSpace(gl);
            pyramid.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            pyramid.PopObjectSpace(gl);
            pyramid.DestroyInContext(gl);

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

            SharpGL.SceneGraph.Quadrics.Cylinder pyramid = new SharpGL.SceneGraph.Quadrics.Cylinder();
            pyramid.TopRadius = SizeY;
            pyramid.BaseRadius = SizeX;
            pyramid.Height = SizeZ;
            pyramid.Slices = Slices;
            pyramid.Stacks = Stacks;
            pyramid.QuadricDrawStyle = DrawStyle.Line;

            pyramid.CreateInContext(gl);
            pyramid.PushObjectSpace(gl);
            pyramid.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            pyramid.PopObjectSpace(gl);
            pyramid.DestroyInContext(gl);

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

            SharpGL.SceneGraph.Quadrics.Cylinder pyramid = new SharpGL.SceneGraph.Quadrics.Cylinder();
            pyramid.TopRadius = SizeY;
            pyramid.BaseRadius = SizeX;
            pyramid.Height = SizeZ;
            pyramid.Slices = Slices;
            pyramid.Stacks = Stacks;
            pyramid.QuadricDrawStyle = DrawStyle.Fill;

            pyramid.CreateInContext(gl);
            pyramid.PushObjectSpace(gl);
            pyramid.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            pyramid.PopObjectSpace(gl);
            pyramid.DestroyInContext(gl);

            gl.PopMatrix();
        }

    }
}
