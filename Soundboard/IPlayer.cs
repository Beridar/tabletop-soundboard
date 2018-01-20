using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IPlayer : IDisposable
    {
        void Load(ISound sound);
        void Play();
        void PlayToCompletion();
        void Stop();
        PlaybackState CurrentPlaybackState { get; }
    }

    public class Player : IPlayer
    {
        protected ISound reader;
        protected IWavePlayer player;

        public Player(IWavePlayer wavePlayer)
        {
            player = wavePlayer;
        }

        public void Dispose()
        {
            if (player?.PlaybackState == PlaybackState.Playing)
                player?.Stop();

            reader?.Dispose();
            player?.Dispose();
        }

        public void Load(ISound sound)
        {
            reader = sound;
            player.Init(reader);
        }

        public void Play()
        {
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