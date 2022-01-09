// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType.Internal;

/// <summary>
/// A structure used to describe a bitmap or pixmap to the raster. Note that we now manage pixmaps of various depths through the <see cref="FTBitmap.PixelMode"/> field.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct FTBitmap
{
    /// <summary>
    /// The number of bitmap rows.
    /// </summary>
    public uint Rows { get; set; }

    /// <summary>
    /// The number of pixels in bitmap row.
    /// </summary>
    public uint Width { get; set; }

    /// <summary>
    /// The pitch's absolute value is the number of bytes taken by one bitmap row, including padding.
    /// However, the pitch is positive when the bitmap has a ‘down’ flow, and negative when it has an ‘up’ flow.
    /// In all cases, the pitch is an offset to add to a bitmap pointer in order to go down one row.
    /// </summary>
    /// <remarks>
    /// Note that ‘padding’ means the alignment of a bitmap to a byte border, and FreeType functions normally align to the smallest possible integer value.
    /// For the B/W rasterizer, pitch is always an even number.
    /// To change the pitch of a bitmap (say, to make it a multiple of 4), use FT_Bitmap_Convert.Alternatively, you might use callback functions to directly
    ///  render to the application's surface; see the file example2.cpp in the tutorial for a demonstration.
    /// </remarks>
    public int Pitch { get; set; }

    /// <summary>
    /// A typeless pointer to the bitmap buffer. This value should be aligned on 32-bit boundaries in most cases.
    /// </summary>
    public IntPtr Buffer { get; set; }

    /// <summary>
    /// This field is only used with <see cref="Enums.PixelMode.Gray"/>, <see cref="Enums.PixelMode.Gray2"/> or <see cref="Enums.PixelMode.Gray4"/>; it gives the number of gray levels used in the bitmap.
    /// </summary>
    public ushort GraysCount { get; set; }

    /// <summary>
    /// The pixel mode, i.e., how pixel bits are stored. See <see cref="Enums.PixelMode"/> for possible values.
    /// </summary>
    public PixelMode PixelMode { get; set; }

    /// <summary>
    /// This field is intended for paletted pixel modes; it indicates how the palette is stored. Not used currently.
    /// </summary>
    public byte PaletteMode { get; set; }

    /// <summary>
    /// A typeless pointer to the bitmap palette; this field is intended for paletted pixel modes. Not used currently.
    /// </summary>
    public IntPtr Palette { get; set; }
}
