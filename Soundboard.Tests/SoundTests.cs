using AutoMoq.Helpers;
using NAudio.Wave;
using NUnit.Framework;
using Should;

namespace Soundboard.Tests
{
    [TestFixture]
    public class SoundTests : AutoMoqTestFixture<Sound>
    {
        [Test]
        public void It_should_be_a_wave_provider()
        {
            Subject.ShouldImplement(typeof(IWaveProvider));
        }
    }
}