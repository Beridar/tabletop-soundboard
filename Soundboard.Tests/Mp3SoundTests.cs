using System;
using System.IO;
using System.Threading;
using AutoMoq.Helpers;
using NAudio.Wave;
using NUnit.Framework;
using Should;

namespace Soundboard.Tests
{
    [TestFixture]
    public class Mp3SoundTests : AutoMoqTestFixture<Mp3Sound>
    {
        [SetUp]
        public void Setup()
        {
        }
    }
}