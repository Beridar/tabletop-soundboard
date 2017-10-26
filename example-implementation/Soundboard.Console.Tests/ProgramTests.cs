using NUnit.Framework;

namespace Soundboard.Console.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void It_should_not_crash()
        {
            Subject.Main(new string[0]);
        }
    }
}