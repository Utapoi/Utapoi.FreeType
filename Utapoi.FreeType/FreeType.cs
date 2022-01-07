// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using Utapoi.FreeType.Exceptions;
using Utapoi.FreeType.Models;

namespace Utapoi.FreeType;

public sealed class FreeType : IDisposable
{
    private IntPtr Library { get; set; }

    public FreeType()
    {
        var result = FreeTypeInvoke.FT_Init_FreeType(out IntPtr library);

        if (result != Error.Ok || library == IntPtr.Zero)
            throw new FreeTypeException($"Failed to Initialize FreeType Library. Error: {result}");

        Library = library;
    }

    ~FreeType()
    {
        ReleaseUnmanagedResources();
    }

    public FontFace LoadFont(string path)
    {
        return new FontFace(Library, path, 0);
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    private void ReleaseUnmanagedResources()
    {
        if (Library == IntPtr.Zero)
            return;

        var result = FreeTypeInvoke.FT_Done_FreeType(Library);

        if (result != Error.Ok)
            throw new FreeTypeException($"Failed to free FreeType Library. Error: {result}");

        Library = IntPtr.Zero;
    }
}
