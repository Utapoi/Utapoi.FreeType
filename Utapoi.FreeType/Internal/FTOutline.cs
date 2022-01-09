// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType.Internal;

/// <summary>
/// This structure is used to describe an outline to the scan-line converter.
/// </summary>
/// <remarks>
/// The B/W rasterizer only checks bit 2 in the tags array for the first point of each contour.
/// The drop-out mode as given with <see cref="Enums.OutlineFlags.IgnoreDropouts"/>, <see cref="Enums.OutlineFlags.SmartDropouts"/> and <see cref="Enums.OutlineFlags.IncludeStubs"/> in flags is then overridden.
/// </remarks>
[StructLayout(LayoutKind.Sequential)]
internal struct FTOutline
{
    /// <summary>
    /// The number of contours in the outline.
    /// </summary>
    public short ContoursCount { get; set; }

    /// <summary>
    /// The number of points in the outline.
    /// </summary>
    public short PointsCount { get; set; }

    /// <summary>
    /// A pointer to an array of <see cref="FTVector2"/> elements, giving the outline's point coordinates.
    /// </summary>
    public IntPtr Points { get; set; }

    /// <summary>
    /// A pointer to an array of n_points chars, giving each outline point's type.
    /// </summary>
    /// <remarks>
    /// If bit 0 is unset, the point is ‘off’ the curve, i.e., a Bezier control point, while it is ‘on’ if set.
    /// <br></br><br></br>
    /// Bit 1 is meaningful for ‘off’ points only. If set, it indicates a third-order Bezier arc control point; and a second-order control point if unset.
    /// <br></br><br></br>
    /// If bit 2 is set, bits 5-7 contain the drop-out mode (as defined in the OpenType specification; the value is the same as the argument to the ‘SCANMODE’ instruction).
    /// <br></br><br></br>
    /// Bits 3 and 4 are reserved for internal purposes.
    /// </remarks>
    public IntPtr Tags { get; set; }

    /// <summary>
    /// An array of n_contours shorts, giving the end point of each contour within the outline.
    /// </summary>
    /// <remarks>
    /// For example, the first contour is defined by the points ‘0’ to contours[0], the second one is defined by the points contours[0]+1 to contours[1], etc.
    /// </remarks>
    public IntPtr Contours { get; set; }

    /// <summary>
    /// A set of bit flags used to characterize the outline and give hints to the scan-converter and hinter on how to convert/grid-fit it.
    /// See <see cref="Enums.OutlineFlags"/>.
    /// </summary>
    public OutlineFlags Flags { get; set; }
}
