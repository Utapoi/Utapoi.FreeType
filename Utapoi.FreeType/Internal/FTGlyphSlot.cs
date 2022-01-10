// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTGlyphSlot
{
    public IntPtr Library { get; set; }

    public IntPtr Face { get; set; }

    public IntPtr Next { get; set; }

    public uint GlyphIndex { get; set; }

    public FTGeneric Generic { get; set; }

    public FTGlyphMetrics Metrics { get; set; }

    public CLong LinearHorizontalAdvance { get; set; }

    public CLong LinearVerticalAdvance { get; set; }

    public FTVector2 Advance { get; set; }

    public GlyphFormat Format { get; set; }

    public FTBitmap Bitmap { get; set; }

    public int BitmapLeft { get; set; }

    public int BitmapTop { get; set; }

    public FTOutline Outline { get; set; }

    public int SubGlyphsCount { get; set; }

    public IntPtr SubGlyphs { get; set; }

    public IntPtr ControlData { get; set; }

    public CLong ControlLength { get; set; }

    public CLong LsbDelta { get; set; }

    public CLong RsbDelta { get; set; }

    public IntPtr Other { get; set; }

    private IntPtr Internal { get; set; }
}
