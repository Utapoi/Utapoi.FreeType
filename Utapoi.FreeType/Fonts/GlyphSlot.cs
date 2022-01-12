// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;
using Utapoi.FreeType.Exceptions;
using Utapoi.FreeType.Internal;

namespace Utapoi.FreeType.Fonts;

public class GlyphSlot
{
    private IntPtr Handle { get; }

    private Face Font { get; }

    private FTGlyphSlot InternalGlyphSlot { get; set; }

    public GlyphSlot(IntPtr glyph, Face font)
    {
        if (glyph != IntPtr.Zero)
            InternalGlyphSlot = Marshal.PtrToStructure<FTGlyphSlot>(glyph);

        Handle = glyph;
        Font = font;
    }

    #region Properties

    public GlyphFormat Format => InternalGlyphSlot.Format;

    public Bitmap Bitmap => new(InternalGlyphSlot.Bitmap, InternalGlyphSlot.BitmapLeft, InternalGlyphSlot.BitmapTop);

    public int Left => InternalGlyphSlot.BitmapLeft;

    public int Top => InternalGlyphSlot.BitmapTop;

    #endregion

    /// <summary>
    /// Convert a given glyph image to a bitmap. It does so by inspecting the glyph image format, finding the relevant renderer, and invoking it.
    /// </summary>
    /// <param name="renderMode"></param>
    /// <returns></returns>
    /// <exception cref="ObjectDisposedException"></exception>
    /// <exception cref="FreeTypeException"></exception>
    public void Render(RenderMode renderMode)
    {
        var result = FreeTypeInvoke.FT_Render_Glyph(Handle, (int)renderMode);

        if (result != Error.Ok)
            throw new FreeTypeException($"Failed to convert glyph to a bitmap. Error: {result}");

        InternalGlyphSlot = Marshal.PtrToStructure<FTGlyphSlot>(Handle);
    }
}
