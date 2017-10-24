using System;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IMp3Player : IPlayer
    {
    }

    public class Mp3Player : IMp3Player, IDisposable
    {
        private WaveOutEvent player;

        public Task Play()
        {
            throw new System.NotImplementedException();
        }

        public void PlayToCompletion()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public PlaybackState CurrentPlaybackState => player?.PlaybackState ?? PlaybackState.Paused;

        public void Dispose()
        {
            player?.Dispose();
        }
    }
}