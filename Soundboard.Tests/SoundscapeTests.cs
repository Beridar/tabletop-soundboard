using System;
using System.IO;
using AutoMoq;
using AutoMoq.Helpers;
using Moq;
using NAudio.Wave;
using NUnit.Framework;
using Should;

namespace Soundboard.Tests
{
    [TestFixture]
    public class SoundscapeTests : AutoMoqTestFixture<Soundscape>
    {
        private Mock<SilencePlayer> theSilenceSound;
        private Mock<IPlayer> anySound;
        private Mock<IPlayer> anotherSound;

        [SetUp]
        public void Setup()
        {
            ResetSubject();

            var moqer = new AutoMoqer();

            theSilenceSound = moqer.GetMock<SilencePlayer>();
            anySound = moqer.GetMock<IPlayer>();
            anotherSound = moqer.GetMock<IPlayer>();
        }

        [Test]
        public void It_should_loop_a_background_sound()
        {
            Subject.AddBackgroundSound(anySound.Object);
        }

        [Test]
        public void It_should_play_a_background_sound_when_told_to_play()
        {
            Subject.AddBackgroundSound(anySound.Object);

            Subject.Play();

            anySound.Verify(x => x.Play(), Times.AtLeastOnce());
        }

        [Test]
        public void Its_playback_status_should_be_playing_when_one_background_sound_is_playing()
        {
            // Missing setup here

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
        }

        [Test]
        public void Its_playback_status_should_be_stopped_when_no_background_sounds_are_playing()
        {
            // Missing setup here

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }

        [Test]
        public void It_should_stop_all_sound_when_requested()
        {
            Subject.AddBackgroundSound(anySound.Object);
            Subject.AddBackgroundSound(anotherSound.Object);

            Subject.Stop();

            anySound.Verify(x => x.Stop(), Times.AtLeastOnce());
            anotherSound.Verify(x => x.Stop(), Times.AtLeastOnce());
        }
    }
}