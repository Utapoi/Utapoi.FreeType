// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTSize
{
    public IntPtr Face { get; set; }

    public FTGeneric Generic { get; set; }

    public FTSizeMetrics Metrics { get; set; }

    #region Private

    private IntPtr Internal { get; set; }

    #endregion

    public static int SizeInBytes => Marshal.SizeOf(typeof(FTSize));
}
