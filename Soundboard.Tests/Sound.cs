﻿using NAudio.Wave;

namespace Soundboard.Tests
{
    public class Sound : IWaveProvider
    {
        public int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }

        public WaveFormat WaveFormat { get; }
    }
}