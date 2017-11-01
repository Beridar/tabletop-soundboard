using NAudio.Wave;

namespace Soundboard
{
    public abstract class Sound : IWaveProvider
    {
        public abstract int Read(byte[] buffer, int offset, int count);

        public WaveFormat WaveFormat { get; }
    }
}