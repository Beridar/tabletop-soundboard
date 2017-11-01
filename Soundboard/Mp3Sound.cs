using NAudio.Wave;

namespace Soundboard
{
    public interface IMp3Player : ISound
    {
    }

    public class Mp3Sound : Sound, IMp3Player
    {
        public override void LoadFile(string filename)
        {
            Dispose();

            reader = new Mp3FileReader(filename);
            player = new WaveOutEvent();
        }
    }
}