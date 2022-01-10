// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTBoundingBox
{
    public CLong MinX { get; set; }

    public CLong MinY { get; set; }

    public CLong MaxX { get; set; }

    public CLong MaxY { get; set; }
}
