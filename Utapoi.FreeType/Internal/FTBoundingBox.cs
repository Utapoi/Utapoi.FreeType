// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTBoundingBox
{
    public long MinX { get; set; }

    public long MinY { get; set; }

    public long MaxX { get; set; }

    public long MaxY { get; set; }
}
