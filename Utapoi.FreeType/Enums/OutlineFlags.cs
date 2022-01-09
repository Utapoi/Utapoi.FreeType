// Copyright (c) Utapoi Ltd <contact@utapoi.com>

namespace Utapoi.FreeType.Enums;

[Flags]
public enum OutlineFlags
{
    None           = 0x0,
    Owner          = 0x1,
    EvenOddFill    = 0x2,
    ReverseFill    = 0x4,
    IgnoreDropouts = 0x8,
    SmartDropouts  = 0x10,
    IncludeStubs   = 0x20,
    Overlap        = 0x40,
    HighPrecision  = 0x100,
    SinglePass     = 0x200
}
