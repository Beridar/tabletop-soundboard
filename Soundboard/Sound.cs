using NAudio.Wave;

namespace Soundboard
{
    public interface ISound : IWaveProvider
    {
    }

    public abstract class Sound : ISound
    {
        public abstract int Read(byte[] buffer, int offset, int count);
        public abstract WaveFormat WaveFormat { get; }
    }
}