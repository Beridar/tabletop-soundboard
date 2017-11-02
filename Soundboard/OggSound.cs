using NAudio.Vorbis;
using NAudio.Wave;

namespace Soundboard
{
    public interface IOggSound : ISound
    {
    }

    public class OggSound : Sound, IOggSound
    {
        protected VorbisWaveReader reader { get; set; }

        public OggSound()
        {
        }

        public OggSound(string filename)
        {
            LoadFile(filename);
        }

        public void LoadFile(string filename)
        {
            Dispose();

            reader = new VorbisWaveReader(filename);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return reader.Read(buffer, offset, count);
        }

        public override WaveFormat WaveFormat => reader.WaveFormat;

        public override void Dispose()
        {
            reader?.Dispose();
        }
    }
}