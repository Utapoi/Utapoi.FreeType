// Copyright (c) Utapoi Ltd <contact@utapoi.com>

namespace Utapoi.FreeType.Enums;

[Flags]
public enum LoadFlags : long
{
    Default = 0x0,
    NoScale = 1L << 0,
    NoHinting = 1L << 1,
    Render = 1L << 2,
    NoBitmap = 1L << 3,
    VerticalLayout = 1L << 4,
    ForceAutoHint = 1L << 5,
    CropBitmap = 1L << 6,
    Pedantic = 1L << 7,
    IgnoreGlobalAdvanceWidth = 1L << 9,
    NoRecurse = 1L << 10,
    IgnoreTransform = 1L << 11,
    Monochrome = 1L << 12,
    LinearDesign = 1L << 13,
    NoAutoHint = 1L << 15,
    Color = 1L << 20,
    ComputeMetrics = 1L << 21,
    BitmapMetricsOnly = 1L << 22,
}
