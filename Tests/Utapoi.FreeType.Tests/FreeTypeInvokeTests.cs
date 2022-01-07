using NUnit.Framework;
using Utapoi.FreeType.Models;

namespace Utapoi.FreeType.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Init_FreeType()
        {
            var result = FreeTypeInvoke.FT_Init_FreeType(out var ptr);

            Assert.IsNotNull(ptr);
            Assert.AreEqual(Error.Ok, result);
        }

        [Test]
        public void Done_FreeType()
        {
            var result = FreeTypeInvoke.FT_Init_FreeType(out var ptr);

            Assert.IsNotNull(ptr);
            Assert.AreEqual(Error.Ok, result);

            result = FreeTypeInvoke.FT_Done_FreeType(ptr);

            Assert.AreEqual(Error.Ok, result);
        }

        [Test]
        public void LibraryVersion_FreeType()
        {
            var result = FreeTypeInvoke.FT_Init_FreeType(out var ptr);

            Assert.IsNotNull(ptr);
            Assert.AreEqual(Error.Ok, result);

            FreeTypeInvoke.FT_Library_Version(ptr, out var major, out var minor, out var patch);

            Assert.GreaterOrEqual(2, major);
            Assert.GreaterOrEqual(11, minor);
            Assert.GreaterOrEqual(1, patch);

            result = FreeTypeInvoke.FT_Done_FreeType(ptr);

            Assert.AreEqual(Error.Ok, result);
        }
    }
}
