using NAudio.Vorbis;
using NAudio.Wave;

namespace Soundboard
{
    public interface IOggSound : ISound
    {
    }

    public class OggSound : Sound, IOggSound
    {
        public void LoadFile(string filename)
        {
            Dispose();

            reader = new VorbisWaveReader(filename);
            player = new WaveOutEvent();
        }
    }
}