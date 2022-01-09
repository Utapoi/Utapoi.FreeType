// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTVector2
{
    public long X { get; set; }

    public long Y { get; set; }
}
