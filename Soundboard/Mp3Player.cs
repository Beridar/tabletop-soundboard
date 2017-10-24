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
        private Mp3FileReader reader;

        public void LoadFile(string filename)
        {
            reader = new Mp3FileReader(filename);
            player = new WaveOutEvent();
            player.Init(reader);
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
            reader?.Dispose();
        }
    }
}