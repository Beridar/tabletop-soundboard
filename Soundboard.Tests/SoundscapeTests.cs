﻿using System;
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
        private Mock<IPlayer> theBackgroundSound;

        [SetUp]
        public void Setup()
        {
            ResetSubject();

            var moqer = new AutoMoqer();

            theBackgroundSound = moqer.GetMock<IPlayer>();
        }

        [Test]
        public void It_should_loop_a_background_sound()
        {
            Subject.AddBackgroundSound(theBackgroundSound.Object);
        }

        [Test]
        public void It_should_play_a_background_sound_when_told_to_play()
        {
            Subject.AddBackgroundSound(theBackgroundSound.Object);

            Subject.Play();

            theBackgroundSound.Verify(x => x.Play(), Times.AtLeastOnce());
        }

        [Test]
        public void It_should_report_its_playback_status()
        {
            Subject.AddBackgroundSound(theBackgroundSound.Object);

            Subject.CurrentPlaybackState.ShouldBeSameAs(PlaybackState.Playing);
        }
    }
}