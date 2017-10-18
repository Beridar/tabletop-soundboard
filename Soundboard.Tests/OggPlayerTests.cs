using System.IO;
using NUnit.Framework;

namespace Soundboard.Tests
{
    [TestFixture]
    public class OggPlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_read_an_ogg_file(string pathToOggFile)
        {
            using (var vorbis = new NVorbis.VorbisReader(GetTheProjectRelativePathForThisProjectFile(pathToOggFile)))
            {
            }
        }

        private static string GetTheProjectRelativePathForThisProjectFile(string projectFileName)
        {
            return Path.Combine(@"\projects\tabletop-soundboard\", projectFileName);
        }
    }
}
