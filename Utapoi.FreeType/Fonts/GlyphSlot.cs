// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;
using Utapoi.FreeType.Internal;

namespace Utapoi.FreeType.Fonts;

public class GlyphSlot
{
    private Face Font { get; }

    private FTGlyphSlot InternalGlyphSlot { get; }

    public GlyphSlot(IntPtr glyph, Face font)
    {
        if (glyph != IntPtr.Zero)
            InternalGlyphSlot = Marshal.PtrToStructure<FTGlyphSlot>(glyph);

        Font = font;
    }

    #region Properties

    public GlyphFormat Format => InternalGlyphSlot.Format;

    public Bitmap Bitmap => new(InternalGlyphSlot.Bitmap, InternalGlyphSlot.BitmapLeft, InternalGlyphSlot.BitmapTop);

    public int Left => InternalGlyphSlot.BitmapLeft;

    public int Top => InternalGlyphSlot.BitmapTop;


    #endregion
}
