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

    private FTGlyphSlot InternalSlot { get; }

    private FTGlyph InternalGlyph { get; }


    public Glyph(IntPtr glyphSlot, Face face, ulong glyphCode)
    {
        var result = FreeTypeInvoke.FT_Get_Glyph(glyphSlot, out var glyph);

        if (result != Error.Ok)
            throw new FreeTypeException($"Failed to get glyph {glyphSlot}. Error: {result}");

        GlyphCode = glyphCode;
        Handle = glyph;
        InternalGlyph = Marshal.PtrToStructure<FTGlyph>(glyph);
        InternalSlot = Marshal.PtrToStructure<FTGlyphSlot>(glyphSlot);
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

            return new Bitmap(InternalSlot.Bitmap, InternalSlot.BitmapLeft, InternalSlot.BitmapTop);
        }
    }

    #endregion

    public void Dispose()
    {
        if (IsDisposed)
            return;

        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
        IsDisposed = true;
    }

    private void ReleaseUnmanagedResources()
    {
        if (Handle == IntPtr.Zero)
            return;

        FreeTypeInvoke.FT_Done_Glyph(Handle);
        Handle = IntPtr.Zero;
    }
}
