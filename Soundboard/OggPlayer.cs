using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVorbis;

namespace Soundboard
{
    public interface IOggPlayer { }

    public class OggPlayer : IOggPlayer, IDisposable
    {
        private NVorbis.VorbisReader reader;

        public void LoadOggFile(string theOggFile)
        {
            reader = new VorbisReader(theOggFile);
        }

        public void Dispose()
        {
            reader?.Dispose();
        }
    }
}
