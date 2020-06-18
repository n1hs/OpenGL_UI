using SharpGL;
using SharpGL.SceneGraph.Quadrics;
using System;

namespace DoAn_OpenGL.Graphics3D
{
    public interface Graphic3D
    {
        double LocationX { get;}
        double LocationY { get;}
        double LocationZ { get;}

        double SizeX { get; }
        double SizeY { get; }
        double SizeZ { get;  }

        double ColorR { get;  }
        double ColorG { get;  }
        double ColorB { get;  }

        double RotateX { get; }
        double RotateY { get; }
        double RotateZ { get; }

        string Name { get; }

        DrawStyle Style { get;  }

        void DrawSolid(OpenGL gl);

    }
}
