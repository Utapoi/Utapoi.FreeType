// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System;
using NUnit.Framework;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType.Tests;

[TestFixture]
public class GlyphRenderTests
{
    private FreeType? _freeType;

    [OneTimeSetUp]
    public void Setup()
    {
        _freeType = new FreeType();
    }

    [Test]
    [TestCase("Fonts/Roboto-Regular.ttf", 'A')]
    [TestCase("Fonts/OpenSans-Bold.ttf", 'B')]
    [TestCase("Fonts/Roboto-Regular.ttf", 'C')]
    [TestCase("Fonts/OpenSans-Bold.ttf", 'D')]
    [TestCase("Fonts/OpenSans-Bold.ttf", '0')]
    public void GlyphRenderLetter(string font, char c)
    {
        var face = _freeType?.LoadFace(font);

        Assert.IsNotNull(face);

        var glyph = face?.LoadGlyph(c);

        Assert.IsNotNull(glyph);
        Assert.AreEqual(c, glyph?.GlyphCode);
        Assert.DoesNotThrow(() => glyph?.Render(RenderMode.Normal));
        Assert.AreNotEqual(0, glyph?.Bitmap.Buffer.Length);
    }
}
