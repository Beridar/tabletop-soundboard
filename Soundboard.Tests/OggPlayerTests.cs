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
        [TestCase(@"\projects\tabletop-soundboard\example-sounds\example.ogg")]
        public void It_can_read_an_ogg_file(string pathToOggFile)
        {
            using (var vorbis = new NVorbis.VorbisReader(pathToOggFile))
            {
            }
        }
    }
}
