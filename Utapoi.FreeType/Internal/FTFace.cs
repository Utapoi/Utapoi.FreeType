// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using FTLong = System.IntPtr;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTFace
{
    public long Count { get; set; }

    public long Index { get; set; }

    public long FaceFlags { get; set; }

    public long StyleFlags { get; set; }

    public long GlyphCount { get; set; }

    public IntPtr FamilyName { get; set; }

    public IntPtr StyleName { get; set; }

    public int FixedSizesCount { get; set; }

    public IntPtr AvailableSizes { get; set; }

    public int CharacterMapsCount { get; set; }

    public IntPtr CharacterMaps { get; set; }

    public FTGeneric Generic { get; set; }

    public FTBoundingBox BoundingBox { get; set; }

    public ushort UnitsPerEM { get; set; }

    public short Ascender { get; set; }

    public short Descender { get; set; }

    public short Height { get; set; }

    public short MaxAdvanceWidth { get; set; }

    public short MaxAdvanceHeight { get; set; }

    public short UnderlinePosition { get; set; }

    public short UnderlineThickness { get; set; }

    public IntPtr Glyph { get; set; }

    public IntPtr Size { get; set; }

    public IntPtr CharMap { get; set; }

    #region Private

    private IntPtr Driver { get; set; }

    private IntPtr Memory { get; set; }

    public IntPtr Stream { get; set; }

    private IntPtr SizesList { get; set; }

    private FTGeneric AutoHint { get; set; }

    private IntPtr Extensions { get; set; }

    private IntPtr Internal { get; set; }

    #endregion

    public static int SizeInBytes => Marshal.SizeOf(typeof(FTFace));
}
