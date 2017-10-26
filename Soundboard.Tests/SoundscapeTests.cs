using System;
using System.IO;
using System.Linq;
using AutoMoq;
using AutoMoq.Helpers;
using Moq;
using NAudio.Wave;
using NUnit.Framework;
using Should;

namespace Soundboard.Tests
{
    public class SoundscapeTests
    {
        [TestFixture]
        public class BackgroundTests : AutoMoqTestFixture<Soundscape>
        {
            private Mock<IPlayer> anySound;
            private Mock<IPlayer> anotherSound;

            [SetUp]
            public void Setup()
            {
                ResetSubject();

                var moqer = new AutoMoqer();

                anySound = moqer.GetMock<IPlayer>();
                anotherSound = moqer.GetMock<IPlayer>();
            }

            [Test]
            public void It_should_add_a_background_sound()
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
                anySound
                    .Setup(x => x.CurrentPlaybackState)
                    .Returns(PlaybackState.Playing);

                Subject.AddBackgroundSound(anySound.Object);
                Subject.Play();

                Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Playing);
            }

            [Test]
            public void
                Its_playback_status_should_be_stopped_when_no_background_sounds_are_available_and_playback_was_requested()
            {
                Subject.Play();

                Subject.CurrentPlaybackState.ShouldEqual(PlaybackState.Stopped);
            }

            [Test]
            public void Its_playback_status_should_be_stopped_when_no_background_sounds_are_available_but_not_playing()
            {
                anySound
                    .Setup(x => x.CurrentPlaybackState)
                    .Returns(PlaybackState.Stopped);

                Subject.AddBackgroundSound(anySound.Object);

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

        [TestFixture]
        public class RecurringSoundTests : AutoMoqTestFixture<Soundscape>
        {
            private Mock<IPlayer> anySound;
            private Mock<IPlayer> anotherSound;

            [SetUp]
            public void Setup()
            {
                ResetSubject();

                var moqer = new AutoMoqer();

                anySound = moqer.GetMock<IPlayer>();
                anotherSound = moqer.GetMock<IPlayer>();
            }

            [Test]
            public void It_should_add_a_recurring_sound()
            {
                Subject.AddRecurringSound(anySound.Object);
            }

            [Test]
            public void It_should_add_a_recurring_sound_with_a_frequency()
            {
                Subject.AddRecurringSound(anySound.Object, PlaybackFrequency.LoopIndefinitely);
            }

            [Test]
            public void It_should_report_what_recurring_sounds_are_available()
            {
                Subject.AddRecurringSound(anySound.Object);

                Subject.RecurringSounds
                    .Any(x => x == anySound.Object)
                    .ShouldEqual(true);
            }
        }
    }
}