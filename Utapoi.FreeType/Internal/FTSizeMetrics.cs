// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTSizeMetrics
{
    /// <summary>
    ///     he width of the scaled EM square in pixels, hence the term ‘ppem’ (pixels per EM).
    /// It is also referred to as ‘nominal width’.
    /// </summary>
    public ushort PpemX { get; set; }

    /// <summary>
    ///     The height of the scaled EM square in pixels, hence the term ‘ppem’ (pixels per EM).
    ///     It is also referred to as ‘nominal height’.
    /// </summary>
    public ushort PpemY { get; set; }

    /// <summary>
    ///     A 16.16 fractional scaling value to convert horizontal metrics from font units to 26.6 fractional pixels.
    ///     Only relevant for scalable font formats.
    /// </summary>
    public long ScaleX { get; set; }

    /// <summary>
    ///     A 16.16 fractional scaling value to convert vertical metrics from font units to 26.6 fractional pixels.
    ///     Only relevant for scalable font formats.
    /// </summary>
    public long ScaleY { get; set; }

    /// <summary>
    ///     The ascender in 26.6 fractional pixels, rounded up to an integer value.
    ///     See <see cref="FTFace"/> for the details.
    /// </summary>
    public long Ascender { get; set; }

    /// <summary>
    ///     The descender in 26.6 fractional pixels, rounded down to an integer value.
    ///     See <see cref="FTFace"/> for the details.
    /// </summary>
    public long Descender { get; set; }

    /// <summary>
    ///     The height in 26.6 fractional pixels, rounded to an integer value.
    ///     See <see cref="FTFace"/> for the details.
    /// </summary>
    public long Height { get; set; }

    /// <summary>
    ///     The maximum advance width in 26.6 fractional pixels, rounded to an integer value.
    ///     See <see cref="FTFace"/> for the details.
    /// </summary>
    public long MaxAdvance { get; set; }
}
