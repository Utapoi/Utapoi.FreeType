// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTGeneric
{
    public IntPtr Data { get; set; }

    public IntPtr Finalizer { get; set; }
}
