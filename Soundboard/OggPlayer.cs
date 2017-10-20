using System;
using System.Threading.Tasks;
using NAudio.Vorbis;
using NAudio.Wave;
using NVorbis;

namespace Soundboard
{
    public interface IOggPlayer
    {
        Task Play();
        void PlayToCompletion();
    }

    public class OggPlayer : IOggPlayer, IDisposable
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
            if(player?.PlaybackState == PlaybackState.Playing)
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
                System.Threading.Thread.Sleep(50);
        }
    }
}