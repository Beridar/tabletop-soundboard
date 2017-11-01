﻿using AutoMoq.Helpers;
using NAudio.Wave;
using NUnit.Framework;
using Should;

namespace Soundboard.Tests
{
    [TestFixture]
    public class PlayerTests : AutoMoqTestFixture<Player>
    {
        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        public void It_can_play_an_mp3_file(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);

            Subject.LoadFile(theSoundFile);
            Subject.Play();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
        }
    }
}