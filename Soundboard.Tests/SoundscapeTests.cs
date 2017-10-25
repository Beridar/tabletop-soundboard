using System;
using System.IO;
using AutoMoq.Helpers;
using Moq;
using NUnit.Framework;

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

            theBackgroundSound = new Mock<IPlayer>();
        }

        [Test]
        public void It_should_loop_a_background_sound()
        {
            Subject.AddBackgroundSound(theBackgroundSound.Object);
        }
    }
}