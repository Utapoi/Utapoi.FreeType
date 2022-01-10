// Copyright (c) Utapoi Ltd <contact@utapoi.com>

using System;
using System.Linq.Expressions;
using NUnit.Framework;
using Utapoi.FreeType.Enums;

namespace Utapoi.FreeType.Tests;

[TestFixture]
public class FreeTypeTests
{
    [Test]
    [TestCase("Roboto-Regular.ttf")]
    public void FreeType_LoadFont(string path)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        Assert.IsNotNull(font);
    }

    [Test]
    [TestCase("Roboto-Regular.ttf", "Roboto")]
    public void Font_GetFamilyName(string path, string family)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        Assert.IsNotNull(font);
        Assert.AreEqual(family, font.FamilyName);
    }

    [Test]
    [TestCase("OpenSans-Bold.ttf", "")]
    public void Font_GetStyleName(string path, string style)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        //font.SetSize(5)
        //    .LoadGlyph('F');
        ////var lib = new FreeTypeLibrary();
        ////FT.FT_New_Face(lib.Native, path, 0, out var f);
        ////var font = new FreeTypeFaceFacade(lib, f);

        //Assert.NotNull(font);

        ////Assert.AreEqual(style, font.StyleName);

        ////Assert.IsNotNull(font);
    }
}
