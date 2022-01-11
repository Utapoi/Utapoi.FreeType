// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System;
using NUnit.Framework;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType.Tests;

[TestFixture]
public class GlyphTests
{
    private FreeType? _freeType;

    [OneTimeSetUp]
    public void Setup()
    {
        _freeType = new FreeType();
    }

    [Test]
    [TestCase("Fonts/OpenSans-Bold.ttf", 'A')]
    [TestCase("Fonts/Roboto-Regular.ttf", 'H')]
    [TestCase("Fonts/OpenSans-Bold.ttf", '%')]
    [TestCase("Fonts/Roboto-Regular.ttf", '3')]
    public void LoadGlyphFromChar(string font, char c)
    {
        var face = _freeType?.LoadFace(font);

        Assert.IsNotNull(face);

        var glyph = face?.LoadGlyph(c);

        Assert.IsNotNull(glyph);
        Assert.AreEqual(c, glyph?.GlyphCode);
    }

    [Test]
    [TestCase("Fonts/Roboto-Regular.ttf", 'A')]
    [TestCase("Fonts/OpenSans-Bold.ttf", 'H')]
    [TestCase("Fonts/Roboto-Regular.ttf", '%')]
    [TestCase("Fonts/OpenSans-Bold.ttf", '3')]
    public void LoadGlyphWithBitmap(string font, char c)
    {
        var face = _freeType?.LoadFace(font);

        Assert.IsNotNull(face);

        var glyph = face?.LoadGlyph(c, LoadFlags.Render);

        Assert.IsNotNull(glyph);
        Assert.AreEqual(c, glyph?.GlyphCode);
        Assert.IsNotNull(glyph?.Bitmap);
        Assert.IsNotNull(glyph?.Bitmap.RawBuffer);

        // Comparison order is different between Unix/OSX and Windows???
        if (OperatingSystem.IsWindows())
            Assert.GreaterOrEqual(1, glyph?.Bitmap.Buffer.Length);
        else
            Assert.GreaterOrEqual(glyph?.Bitmap.Buffer.Length, 1);
    }

    [Test]
    [TestCase("Fonts/OpenSans-Bold.ttf", 'A')]
    [TestCase("Fonts/Roboto-Regular.ttf", 'H')]
    [TestCase("Fonts/OpenSans-Bold.ttf", '%')]
    [TestCase("Fonts/Roboto-Regular.ttf", '3')]
    public void LoadCharacter(string font, char c)
    {
        var face = _freeType?.LoadFace(font);

        Assert.IsNotNull(face);

        var glyph = face?.LoadCharacter(c);

        Assert.IsNotNull(glyph);
        Assert.AreEqual(c, glyph?.GlyphCode);
    }
}
