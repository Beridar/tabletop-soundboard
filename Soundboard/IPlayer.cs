using System;
using System.Threading;
using NAudio.Wave;

namespace Soundboard
{
    public interface IPlayer : IDisposable
    {
        void Play(ISound sound);
        void PlayToCompletion(ISound sound);
        void Stop();
        PlaybackState CurrentPlaybackState { get; }
    }

    public class Player : IPlayer
    {
        protected ISound reader;
        protected IWavePlayer player;

        public Player() : this(new WaveOut())
        {
        }

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

        public void Play(ISound sound)
        {
            player.Init(reader);
            player.Play();
        }

        public void PlayToCompletion(ISound sound)
        {
            Play(sound);

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