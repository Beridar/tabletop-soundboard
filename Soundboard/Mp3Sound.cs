using NAudio.Wave;

namespace Soundboard
{
    public interface IMp3Player : ISound
    {
    }

    public class Mp3Sound : Sound, IMp3Player
    {
        protected Mp3FileReader reader { get; set; }

        public Mp3Sound(string filename)
        {
            reader = new Mp3FileReader(filename);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return reader.Read(buffer, offset, count);
        }

        public override WaveFormat WaveFormat { get => reader.WaveFormat; }
    }
}