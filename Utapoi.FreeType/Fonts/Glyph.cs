// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;
using Utapoi.FreeType.Exceptions;
using Utapoi.FreeType.Internal;

namespace Utapoi.FreeType.Fonts;

public class Glyph : IDisposable
{
    public ulong GlyphCode { get; }

    private IntPtr Handle { get; set; }

    private bool IsDisposed { get; set; }

    private FTGlyph InternalGlyph { get; }

    private GlyphSlot GlyphSlot { get; }

    public Glyph(IntPtr glyphSlot, Face face, ulong glyphCode)
    {
        var result = FreeTypeInvoke.FT_Get_Glyph(glyphSlot, out var glyph);

        if (result != Error.Ok)
            throw new FreeTypeException($"Failed to get glyph {glyphSlot}. Error: {result}");

        GlyphCode = glyphCode;
        Handle = glyph;
        InternalGlyph = Marshal.PtrToStructure<FTGlyph>(glyph);
        GlyphSlot = new GlyphSlot(glyphSlot, face);
    }

    ~Glyph()
    {
        ReleaseUnmanagedResources();
    }

    #region Properties

    public Bitmap Bitmap
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(Bitmap), "Cannot access a disposed object.");

            return GlyphSlot.Bitmap;
        }
    }

    public long AdvanceX
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(AdvanceX), "Cannot access a disposed object.");

            return InternalGlyph.Advance.X.Value;
        }
    }

    public long AdvanceY
    {
        get
        {
            if (IsDisposed)
                throw new ObjectDisposedException(nameof(AdvanceX), "Cannot access a disposed object.");

            return InternalGlyph.Advance.Y.Value;
        }
    }

    #endregion

    public void Render(RenderMode renderMode)
        => GlyphSlot.Render(renderMode);

    public void Dispose()
    {
        if (IsDisposed)
            return;

        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    private void ReleaseUnmanagedResources()
    {
        IsDisposed = true;

        if (Handle == IntPtr.Zero)
            return;

        FreeTypeInvoke.FT_Done_Glyph(Handle);
        Handle = IntPtr.Zero;
    }
}
