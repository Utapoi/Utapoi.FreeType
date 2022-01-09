// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTGlyphMetrics
{
    public long Width { get; set; }

    public long Height { get; set; }

    public long HorizontalBearingX { get; set; }

    public long HorizontalBearingY { get; set; }

    public long HorizontalAdvance { get; set; }

    public long VerticalBearingX { get; set; }

    public long VerticalBearingY { get; set; }

    public long VerticalAdvance { get; set; }
}
