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
