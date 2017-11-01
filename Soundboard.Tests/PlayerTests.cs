using System;
using System.IO;
using System.Threading;
using AutoMoq.Helpers;
using NAudio.Wave;
using NUnit.Framework;
using Should;

namespace Soundboard.Tests
{
    [TestFixture]
    public class PlayerTests : AutoMoqTestFixture<Player>
    {
        [SetUp]
        public void Setup()
        {
            ResetSubject();
        }

        private static string GetTheProjectRelativePathForThisProjectFile(string projectFileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, projectFileName);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_play_a_sound(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);
            var theMp3File = new Mp3Sound(theSoundFile);

            Subject.Load(theMp3File);
            Subject.Play();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_block_until_mp3_playback_is_complete(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);
            var theMp3File = new Mp3Sound(theSoundFile);

            Subject.Load(theMp3File);
            Subject.PlayToCompletion();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_stop_mp3_playback_before_playback_is_complete(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);
            var theMp3File = new Mp3Sound(theSoundFile);

            Subject.Load(theMp3File);
            Subject.Play();
            Thread.Sleep(500);
            Subject.Stop();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }
    }
}