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
    [TestCase("OpenSans-Bold.ttf", "OpenSans")]
    public void Font_GetFamilyName(string path, string family)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        Assert.IsNotNull(font);
        Assert.AreEqual(family, font.FamilyName);
    }

    [Test]
    [TestCase("Roboto-Regular.ttf", "Regular")]
    [TestCase("OpenSans-Bold.ttf", "Bold")]
    public void Font_GetStyleName(string path, string style)
    {
        using var ft = new FreeType();
        var font = ft.LoadFace(path);

        Assert.IsNotNull(font);
        Assert.AreEqual(style, font.StyleName);
    }
}
