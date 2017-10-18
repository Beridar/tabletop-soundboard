using System;
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
            var theOggFile = GetTheProjectRelativePathForThisProjectFile(pathToOggFile);

            using (var vorbis = new NVorbis.VorbisReader(theOggFile))
            {
            }
        }

        private static string GetTheProjectRelativePathForThisProjectFile(string projectFileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, projectFileName);
        }
    }
}
