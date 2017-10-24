using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IMp3Player : IPlayer
    {
    }

    public class Mp3Player : IMp3Player
    {
        private WaveOutEvent player;
        private Mp3FileReader reader;

        public void LoadFile(string filename)
        {
            Dispose();

            reader = new Mp3FileReader(filename);
            player = new WaveOutEvent();
        }

        public async Task Play()
        {
            player.Init(reader);
            player.Play();
        }

        public void PlayToCompletion()
        {
            Play();

            while (player.PlaybackState == PlaybackState.Playing)
                Thread.Sleep(50);
        }

        public void Stop()
        {
            player.Stop();
        }

        public PlaybackState CurrentPlaybackState => player?.PlaybackState ?? PlaybackState.Paused;

        public void Dispose()
        {
            player?.Dispose();
            reader?.Dispose();
        }
    }
}