using System;
using NAudio.Wave;

namespace Soundboard
{
    public interface ISound : IWaveProvider, IDisposable
    {
    }

    public abstract class Sound : ISound
    {
        public abstract int Read(byte[] buffer, int offset, int count);
        public abstract WaveFormat WaveFormat { get; }
        public abstract void Dispose();
    }
}