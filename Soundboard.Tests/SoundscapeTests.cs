using System;
using System.IO;
using AutoMoq.Helpers;
using NUnit.Framework;

namespace Soundboard.Tests
{
    [TestFixture]
    public class SoundscapeTests : AutoMoqTestFixture<Soundscape>
    {
        private IPlayer theBackgroundSound;

        [SetUp]
        public void Setup()
        {
            ResetSubject();

            theBackgroundSound = new OggPlayer();
            theBackgroundSound.LoadFile(GetTheProjectRelativePathForThisProjectFile(@"example-sounds\mpthreetest.mp3"));
        }

        private static string GetTheProjectRelativePathForThisProjectFile(string projectFileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, projectFileName);
        }

        [Test]
        public void It_should_loop_a_background_sound()
        {
            Subject.AddBackgroundSound(theBackgroundSound);
        }
    }
}