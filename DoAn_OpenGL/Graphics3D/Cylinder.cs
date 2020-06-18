using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public class CylinderGraphic
    {
        //ham ve hinh tru
        public static void DrawCylinder(OpenGL gl, int x1, int y1, int x2, int y2)
        {
            Cylinder cylinder = new Cylinder();
            cylinder.TopRadius = 0.1 * Math.Abs(x2 - x1);
            cylinder.BaseRadius = 0.1 * Math.Abs(x2 - x1);
            cylinder.Height = 0.1 * Math.Abs(y2 - y1);
            cylinder.Slices = 100;
            cylinder.Stacks = 100;

            cylinder.CreateInContext(gl);
            cylinder.PushObjectSpace(gl);
            cylinder.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
            cylinder.PopObjectSpace(gl);
            cylinder.DestroyInContext(gl);
        }
    }
}
