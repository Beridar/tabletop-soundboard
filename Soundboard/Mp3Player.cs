using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IMp3Player : IPlayer
    {
    }

    public class Mp3Player : Player, IMp3Player
    {
        public override void LoadFile(string filename)
        {
            Dispose();

            reader = new Mp3FileReader(filename);
            player = new WaveOutEvent();
        }
    }
}