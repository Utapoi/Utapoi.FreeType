// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using Utapoi.FreeType.Exceptions;
using Utapoi.FreeType.Models;

namespace Utapoi.FreeType;

public sealed class FontFace
{
    private IntPtr _face;

    public FontFace(IntPtr library, string path, int faceIndex)
    {
        if (FreeTypeInvoke.FT_New_Face(library, path, 0, out _face) != Error.Ok)
            throw new FreeTypeException($"Failed to load font {path}.");
    }

    public FontFace(IntPtr library, string path) : this(library, path, 0)
    {
    }
}
