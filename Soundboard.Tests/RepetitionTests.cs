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
    }
}