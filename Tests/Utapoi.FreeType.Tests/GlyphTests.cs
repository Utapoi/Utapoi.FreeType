// Copyright (c) Utapoi Ltd <contact@utapoi.com>

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
    [TestCase("OpenSans-Bold.ttf", 'A')]
    [TestCase("OpenSans-Bold.ttf", 'H')]
    [TestCase("OpenSans-Bold.ttf", '%')]
    [TestCase("OpenSans-Bold.ttf", '3')]
    public void LoadGlyphFromChar(string font, char c)
    {
        using var face = _freeType?.LoadFace(font);

        Assert.IsNotNull(face);

        using var glyph = face?.LoadGlyph(c);

        Assert.IsNotNull(glyph);
        Assert.AreEqual(c, glyph?.GlyphCode);
    }

    [Test]
    [TestCase("OpenSans-Bold.ttf", 'A')]
    [TestCase("OpenSans-Bold.ttf", 'H')]
    [TestCase("OpenSans-Bold.ttf", '%')]
    [TestCase("OpenSans-Bold.ttf", '3')]
    public void LoadGlyphWithBitmap(string font, char c)
    {
        using var face = _freeType?.LoadFace(font);

        Assert.IsNotNull(face);

        using var glyph = face?.LoadGlyph(c, LoadFlags.Render);

        Assert.IsNotNull(glyph);
        Assert.AreEqual(c, glyph?.GlyphCode);
        Assert.IsNotNull(glyph?.Bitmap);
        Assert.IsNotNull(glyph?.Bitmap.RawBuffer);
        Assert.GreaterOrEqual(1, glyph?.Bitmap.Buffer.Length);
    }

    [Test]
    [TestCase("OpenSans-Bold.ttf", 'A')]
    [TestCase("OpenSans-Bold.ttf", 'H')]
    [TestCase("OpenSans-Bold.ttf", '%')]
    [TestCase("OpenSans-Bold.ttf", '3')]
    public void LoadCharacter(string font, char c)
    {
        using var face = _freeType?.LoadFace(font);

        Assert.IsNotNull(face);

        using var glyph = face?.LoadCharacter(c);

        Assert.IsNotNull(glyph);
        Assert.AreEqual(c, glyph?.GlyphCode);
    }

    [Test]
    [TestCase("OpenSans-Bold.ttf", "HelloWorld")]
    public void LoadCharacters(string font, string text)
    {

    }
}
