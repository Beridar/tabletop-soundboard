using System;
using System.IO;
using AutoMoq.Helpers;
using NUnit.Framework;

namespace Soundboard.Tests
{
    [TestFixture]
    public class OggPlayerTests : AutoMoqTestFixture<OggPlayer>
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
        public void It_can_load_an_ogg_file(string pathToOggFile)
        {
            var theOggFile = GetTheProjectRelativePathForThisProjectFile(pathToOggFile);

            Subject.LoadOggFile(theOggFile);
        }

        [Test]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_play_an_ogg_file(string pathToOggFile)
        {
            var theOggFile = GetTheProjectRelativePathForThisProjectFile(pathToOggFile);

            Subject.LoadOggFile(theOggFile);
            Subject.Play();
        }
    }
}