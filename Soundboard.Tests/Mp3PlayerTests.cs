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
    public class Mp3PlayerTests : AutoMoqTestFixture<Mp3Player>
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
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        public void It_can_load_an_mp3_file(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);

            Subject.LoadFile(theSoundFile);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        public void It_can_play_an_mp3_file(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);

            Subject.LoadFile(theSoundFile);
            Subject.Play();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        public void It_can_block_until_playback_is_complete(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);

            Subject.LoadFile(theSoundFile);
            Subject.PlayToCompletion();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        public void It_can_stop_playback_before_playback_is_complete(string pathToSoundFile)
        {
            var theSoundFile = GetTheProjectRelativePathForThisProjectFile(pathToSoundFile);

            Subject.LoadFile(theSoundFile);
            Subject.Play();
            Thread.Sleep(500);
            Subject.Stop();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }
    }
}