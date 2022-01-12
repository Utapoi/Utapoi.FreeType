// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System.Runtime.InteropServices;

namespace Utapoi.FreeType.Internal;

[StructLayout(LayoutKind.Sequential)]
internal struct FTVector2
{
    public CLong X { get; set; }

    public CLong Y { get; set; }
}
