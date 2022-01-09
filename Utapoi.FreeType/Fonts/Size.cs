// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;
using Utapoi.FreeType.Internal;

namespace Utapoi.FreeType.Fonts;

public class Size
{
    private Face Face { get; }

    private FTSize InternalSize { get; }

    public Size(IntPtr size, Face face)
    {
        if (size != IntPtr.Zero)
            InternalSize = Marshal.PtrToStructure<FTSize>(size);

        Face = face;
    }

    #region Properties

    public ushort NominalWidth => InternalSize.Metrics.PpemX;

    public ushort NominalHeight => InternalSize.Metrics.PpemY;

    public long ScaleX => InternalSize.Metrics.ScaleX >> 6;

    public long ScaleY => InternalSize.Metrics.ScaleY >> 6;

    public long Ascender => InternalSize.Metrics.Ascender >> 6;

    public long Descender => InternalSize.Metrics.Descender >> 6;

    public long Height => InternalSize.Metrics.Height >> 6;

    public long MaxAdvance => InternalSize.Metrics.MaxAdvance >> 6;

    #endregion

}
