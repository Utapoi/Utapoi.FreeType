// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTGlyphMetrics
{
    public CLong Width { get; set; }

    public CLong Height { get; set; }

    public CLong HorizontalBearingX { get; set; }

    public CLong HorizontalBearingY { get; set; }

    public CLong HorizontalAdvance { get; set; }

    public CLong VerticalBearingX { get; set; }

    public CLong VerticalBearingY { get; set; }

    public CLong VerticalAdvance { get; set; }
}
