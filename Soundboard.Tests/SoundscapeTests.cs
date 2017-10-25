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

        [SetUp]
        public void Setup()
        {
            ResetSubject();

            var moqer = new AutoMoqer();

            theSilenceSound = moqer.GetMock<SilencePlayer>();
        }

        [Test]
        public void It_should_loop_a_background_sound()
        {
            Subject.AddBackgroundSound(theSilenceSound.Object);
        }

        [Test]
        public void It_should_play_a_background_sound_when_told_to_play()
        {
            var anyBackgroundSound = Mocker.GetMock<IPlayer>();

            Subject.AddBackgroundSound(anyBackgroundSound.Object);

            Subject.Play();

            anyBackgroundSound.Verify(x => x.Play(), Times.AtLeastOnce());
        }

        [Test]
        public void It_should_report_its_playback_status()
        {
            Subject.AddBackgroundSound(theSilenceSound.Object);

            Subject.Play();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
        }

        [Test]
        public void It_should_stop_all_sound_when_requested()
        {
            Subject.AddBackgroundSound(theSilenceSound.Object);

            Subject.Stop();

            Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
        }
    }
}