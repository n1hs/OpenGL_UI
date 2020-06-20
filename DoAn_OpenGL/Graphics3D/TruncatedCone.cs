using SharpGL;
using SharpGL.SceneGraph.Quadrics;

namespace DoAn_OpenGL.Graphics3D
{
    public class TruncatedCone : Graphic3D
    {
        public TruncatedCone(DrawStyle style, double baseRadius, double topRadius, double height, double R, double G, double B, double tranX = 0, double tranY = 0, double tranZ = 0, double rotX = 0, double rotY = 0, double rotZ = 0)
        {
            Style = style;
            Name = "Truncated Cone";
            SizeX = baseRadius;
            SizeY = topRadius;
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
            SharpGL.SceneGraph.Quadrics.Cylinder truncatedCone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            truncatedCone.TopRadius = SizeY;
            truncatedCone.BaseRadius = SizeX;
            truncatedCone.Height = SizeZ;
            truncatedCone.Slices = 100;
            truncatedCone.Stacks = 100;
            truncatedCone.QuadricDrawStyle = DrawStyle.Point;
            truncatedCone.CreateInContext(gl);
            truncatedCone.PushObjectSpace(gl);
            truncatedCone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            truncatedCone.PopObjectSpace(gl);
            truncatedCone.DestroyInContext(gl);
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
            SharpGL.SceneGraph.Quadrics.Cylinder truncatedCone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            truncatedCone.TopRadius = SizeY;
            truncatedCone.BaseRadius = SizeX;
            truncatedCone.Height = SizeZ;
            truncatedCone.Slices = 100;
            truncatedCone.Stacks = 100;
            truncatedCone.QuadricDrawStyle = DrawStyle.Line;
            truncatedCone.CreateInContext(gl);
            truncatedCone.PushObjectSpace(gl);
            truncatedCone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            truncatedCone.PopObjectSpace(gl);
            truncatedCone.DestroyInContext(gl);
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
            SharpGL.SceneGraph.Quadrics.Cylinder truncatedCone = new SharpGL.SceneGraph.Quadrics.Cylinder();
            truncatedCone.TopRadius = SizeY;
            truncatedCone.BaseRadius = SizeX;
            truncatedCone.Height = SizeZ;
            truncatedCone.Slices = 100;
            truncatedCone.Stacks = 100;
            truncatedCone.QuadricDrawStyle = DrawStyle.Fill;
            truncatedCone.CreateInContext(gl);
            truncatedCone.PushObjectSpace(gl);
            truncatedCone.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            truncatedCone.PopObjectSpace(gl);
            truncatedCone.DestroyInContext(gl);
            gl.PopMatrix();
        }

    }
}
