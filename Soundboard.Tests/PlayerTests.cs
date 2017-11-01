using System;
using System.IO;
using System.Threading;
using AutoMoq;
using AutoMoq.Helpers;
using Moq;
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

        private static ISound GetTheSoundImplementationForThisSoundFile(string theSoundFile)
        {
            if (theSoundFile.EndsWith("mp3"))
                return new Mp3Sound(GetTheProjectRelativePathForThisProjectFile(theSoundFile));
            if (theSoundFile.EndsWith("ogg"))
                return new OggSound(GetTheProjectRelativePathForThisProjectFile(theSoundFile));

            return null;
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_play_a_sound(string pathToSoundFile)
        {
            var theSoundFile = GetTheSoundImplementationForThisSoundFile(pathToSoundFile);

            Subject.Load(theSoundFile);
            Subject.Play();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_block_until_playback_is_complete(string pathToSoundFile)
        {
            var theSoundFile = GetTheSoundImplementationForThisSoundFile(pathToSoundFile);

            Subject.Load(theSoundFile);
            Subject.PlayToCompletion();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }

        [Test]
        [TestCase(@"example-sounds\mpthreetest.mp3")]
        [TestCase(@"example-sounds\example.ogg")]
        public void It_can_stop_playback_before_playback_is_complete(string pathToSoundFile)
        {
            var theSoundFile = GetTheSoundImplementationForThisSoundFile(pathToSoundFile);

            Subject.Load(theSoundFile);
            Subject.Play();
            Thread.Sleep(500);
            Subject.Stop();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }

        [Test]
        public void It_should_not_orphan_loaded_sounds_when_disposing()
        {
            Subject.Load(Mocked<ISound>().Object);
            Subject.Dispose();

            Mocked<ISound>().Verify(x => x.Dispose(), Times.AtLeastOnce());
        }

        [Test]
        public void It_should_stop_playback_when_disposed()
        {
            Subject.Load(Mocked<ISound>().Object);
            Mocked<IWavePlayer>()
                .Setup(x => x.PlaybackState)
                .Returns(PlaybackState.Playing);

            Subject.Dispose();
            
            Mocked<IWavePlayer>().Verify(x => x.Stop(), Times.AtLeastOnce());
        }
    }
}