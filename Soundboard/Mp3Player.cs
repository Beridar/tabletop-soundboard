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
        private Mp3FileReader mp3FileReader;

        public void LoadFile(string filename)
        {
            mp3FileReader = new Mp3FileReader(filename);
            player = new WaveOutEvent();
            player.Init(mp3FileReader);
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
            mp3FileReader?.Dispose();
        }
    }
}