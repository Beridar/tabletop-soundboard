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
            private Mock<ISound> anySound;
            private Mock<ISound> anotherSound;

            [SetUp]
            public void Setup()
            {
                ResetSubject();

                anySound = Mocked<ISound>();
                anotherSound = Mocked<ISound>();
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

                Mocked<IPlayer>().Verify(x => x.Play(It.Is<ISound>(y => y == anySound.Object)), Times.AtLeastOnce());
            }

            [Test]
            public void Its_playback_status_should_be_playing_when_one_background_sound_is_playing()
            {
                Mocked<IPlayer>()
                    .Setup(x => x.CurrentPlaybackState)
                    .Returns(PlaybackState.Playing);

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
            public void It_should_stop_all_sound_when_requested()
            {
                Subject.AddBackgroundSound(anySound.Object);
                Subject.AddBackgroundSound(anotherSound.Object);

                Subject.Stop();

                Mocked<IPlayer>()
                    .Verify(x => x.Stop(), Times.AtLeastOnce());
            }
        }

        [TestFixture]
        public class RecurringSoundTests : AutoMoqTestFixture<Soundscape>
        {
            [SetUp]
            public void Setup()
            {
                ResetSubject();
            }

            [Test]
            public void It_should_add_a_recurring_sound()
            {
                Subject.AddRecurringSound(Mocked<ISound>().Object);
            }

            [Test]
            public void It_should_add_a_recurring_sound_with_a_frequency()
            {
                Subject.AddRecurringSound(Mocked<ISound>().Object, PlaybackFrequency.LoopIndefinitely);
            }

            [Test]
            public void It_should_report_what_recurring_sounds_are_available()
            {
                Subject.AddRecurringSound(Mocked<ISound>().Object);

                Subject.RecurringSounds
                    .Any(x => x == Mocked<ISound>().Object)
                    .ShouldEqual(true);
            }

            [Test]
            public void It_should_play_an_infinitely_recurring_sound()
            {
                Subject.AddRecurringSound(Mocked<ISound>().Object, PlaybackFrequency.LoopIndefinitely);

                Subject.Play();

                Mocked<IPlayer>().Verify(x => x.Play(It.Is<ISound>(y => y == Mocked<ISound>().Object)), Times.AtLeastOnce());
            }

            [Test]
            public void It_should_stop_an_infinitely_recurring_sound()
            {
                Subject.AddRecurringSound(Mocked<ISound>().Object, PlaybackFrequency.LoopIndefinitely);

                Subject.Stop();

                Mocked<IPlayer>().Verify(x => x.Stop(), Times.AtLeastOnce());
            }
        }
    }
}