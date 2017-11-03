using AutoMoq.Helpers;
using NUnit.Framework;

namespace Soundboard.Tests
{
    [TestFixture]
    public class RepetitionTests : AutoMoqTestFixture<Soundscape>
    {
        [SetUp]
        public void Setup()
        {
            ResetSubject();
        }

        [Test]
        public void It_should_take_a_repetitive_sound()
        {
            var sound = Mocked<ISound>().Object;

            Subject.AddRecurringSound(sound, PlaybackFrequency.OnlyOnDemand);
        }
    }
}