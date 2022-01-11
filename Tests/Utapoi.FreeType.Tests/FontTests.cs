// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using NUnit.Framework;

namespace Utapoi.FreeType.Tests;

[TestFixture]
public class FontTests
{
    [Test]
    [TestCase("Fonts/Roboto-Regular.ttf")]
    public void FreeType_LoadFont(string path)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        Assert.IsNotNull(font);
    }

    [Test]
    [TestCase("Fonts/Roboto-Regular.ttf", "Roboto")]
    [TestCase("Fonts/OpenSans-Bold.ttf", "Open Sans")]
    public void Font_GetFamilyName(string path, string family)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        Assert.IsNotNull(font);
        Assert.AreEqual(family, font.FamilyName);
    }

    [Test]
    [TestCase("Fonts/Roboto-Regular.ttf", "Regular")]
    [TestCase("Fonts/OpenSans-Bold.ttf", "Bold")]
    public void Font_GetStyleName(string path, string style)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        Assert.IsNotNull(font);
        Assert.AreEqual(style, font.StyleName);
    }
}
