using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Vorbis;
using NAudio.Wave;

namespace Soundboard
{
    public interface IOggPlayer : IPlayer
    {
    }

    public class OggPlayer : Player, IOggPlayer
    {
        public override void LoadFile(string filename)
        {
            Dispose();

            reader = new VorbisWaveReader(filename);
            player = new WaveOutEvent();
        }
    }
}