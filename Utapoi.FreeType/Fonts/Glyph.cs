// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;
using Utapoi.FreeType.Exceptions;
using Utapoi.FreeType.Internal;

namespace Utapoi.FreeType.Fonts;

public class Glyph : IDisposable
{
    public IntPtr Handle { get; private set; }

    public bool IsDisposed { get; private set; }

    private FTGlyph InternalGlyph { get; }

    public Glyph(IntPtr library, Face font, int glyphIndex)
    {
    }

    public Glyph(IntPtr glyphSlot, Face face)
    {
        var result = FreeTypeInvoke.FT_Get_Glyph(glyphSlot, out var glyph);

        if (result != Error.Ok)
            throw new FreeTypeException($"Failed to get glyph {glyphSlot}. Error: {result}");

        Handle = glyph;
        InternalGlyph = Marshal.PtrToStructure<FTGlyph>(glyph);
    }

    ~Glyph()
    {
        ReleaseUnmanagedResources();
    }

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
    }
}
