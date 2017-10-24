using System;
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

        public void LoadFile(string filename)
        {
            throw new NotImplementedException();
        }

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