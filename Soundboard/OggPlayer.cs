using System;
using NVorbis;

namespace Soundboard
{
    public interface IOggPlayer
    {
    }

    public class OggPlayer : IOggPlayer, IDisposable
    {
        private VorbisReader reader;

        public void LoadOggFile(string theOggFile)
        {
            reader = new VorbisReader(theOggFile);
        }

        public void Dispose()
        {
            reader?.Dispose();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}