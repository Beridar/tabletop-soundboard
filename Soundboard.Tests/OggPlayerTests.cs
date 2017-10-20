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

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
        }

        [Test]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_block_until_playback_is_complete(string pathToOggFile)
        {
            var theOggFile = GetTheProjectRelativePathForThisProjectFile(pathToOggFile);

            Subject.LoadOggFile(theOggFile);
            Subject.PlayToCompletion();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }

        [Test]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_stop_playback_before_playback_is_complete(string pathToOggFile)
        {
            var theOggFile = GetTheProjectRelativePathForThisProjectFile(pathToOggFile);

            Subject.LoadOggFile(theOggFile);
            Subject.Play();
            Thread.Sleep(500);
            Subject.Stop();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }
    }
}