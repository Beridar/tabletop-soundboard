using System;
using NAudio.Vorbis;
using NVorbis;

namespace Soundboard
{
    public interface IOggPlayer
    {
        void Play();
    }

    public class OggPlayer : IOggPlayer, IDisposable
    {
        private VorbisWaveReader reader;

        public void LoadOggFile(string theOggFile)
        {
            reader = new VorbisWaveReader(theOggFile);
        }

        public void Dispose()
        {
            reader?.Dispose();
        }

        public void Play()
        {
            using (var waveOut = new NAudio.Wave.WaveOutEvent())
            {
                waveOut.Init(reader);
                waveOut.Play();
            }
        }
    }
}