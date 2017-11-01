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
    }
}