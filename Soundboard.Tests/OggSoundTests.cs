﻿using System;
using System.IO;
using System.Threading;
using AutoMoq.Helpers;
using NAudio.Wave;
using NUnit.Framework;
using Should;

namespace Soundboard.Tests
{
    [TestFixture]
    public class OggSoundTests : AutoMoqTestFixture<OggSound>
    {
        [SetUp]
        public void Setup()
        {
        }
    }
}