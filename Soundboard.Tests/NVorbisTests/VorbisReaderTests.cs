using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Soundboard.Tests.NVorbisTests
{
    [TestFixture]
    public class VorbisReaderTests
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
