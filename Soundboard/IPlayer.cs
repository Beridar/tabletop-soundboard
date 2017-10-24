using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IPlayer : IDisposable
    {
        void LoadFile(string filename);
        Task Play();
        void PlayToCompletion();
        void Stop();
        PlaybackState CurrentPlaybackState { get; }
    }

    public abstract class Player : IPlayer
    {
        protected IWaveProvider reader;
        protected WaveOutEvent player;

        public void Dispose()
        {
            if (player?.PlaybackState == PlaybackState.Playing)
                player?.Stop();

            (reader as IDisposable)?.Dispose();
            player?.Dispose();
        }

        public abstract void LoadFile(string filename);

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

        public PlaybackState CurrentPlaybackState => player?.PlaybackState ?? PlaybackState.Stopped;
    }
}