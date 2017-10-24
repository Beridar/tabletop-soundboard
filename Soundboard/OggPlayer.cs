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

    public class OggPlayer : IOggPlayer
    {
        private VorbisWaveReader reader;
        private WaveOutEvent player;

        public void LoadOggFile(string theOggFile)
        {
            Dispose();

            reader = new VorbisWaveReader(theOggFile);
            player = new WaveOutEvent();
        }

        public void Dispose()
        {
            if (player?.PlaybackState == PlaybackState.Playing)
                player?.Stop();

            reader?.Dispose();
            player?.Dispose();
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

        public PlaybackState CurrentPlaybackState => player?.PlaybackState ?? PlaybackState.Stopped;
    }
}