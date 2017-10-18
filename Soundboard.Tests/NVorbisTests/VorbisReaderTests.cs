using System;
using System.IO;
using NUnit.Framework;
using NVorbis;

namespace Soundboard.Tests.NVorbisTests
{
    [TestFixture]
    public class VorbisReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static string GetTheProjectRelativePathForThisProjectFile(string projectFileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, projectFileName);
        }

        [Test]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_read_an_ogg_file(string pathToOggFile)
        {
            var theOggFile = GetTheProjectRelativePathForThisProjectFile(pathToOggFile);

            using (var vorbis = new VorbisReader(theOggFile))
            {
            }
        }
    }
}