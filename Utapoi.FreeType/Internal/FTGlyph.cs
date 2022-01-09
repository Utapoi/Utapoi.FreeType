// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType.Internal;

/// <summary>
/// The root glyph structure contains a given glyph image plus its advance width in 16.16 fixed-point format.
/// </summary>
/// <remarks>
/// Glyph objects are not owned by the library. You must thus release them manually (through FT_Done_Glyph) before calling FT_Done_FreeType.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct FTGlyph
{
    /// <summary>
    /// A handle to the FreeType library object.
    /// </summary>
    public IntPtr Library { get; set; }

    /// <summary>
    /// A pointer to the glyph's class. Private.
    /// </summary>
    private IntPtr Class { get; set; }

    /// <summary>
    /// The format of the glyph's image.
    /// </summary>
    public GlyphFormat Format { get; set; }

    /// <summary>
    /// A 16.16 vector that gives the glyph's advance width.
    /// </summary>
    public FTVector2 Advance { get; set; }
}
