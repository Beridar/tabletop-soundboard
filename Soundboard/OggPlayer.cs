using System;
using System.Threading.Tasks;
using NAudio.Vorbis;
using NAudio.Wave;
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

        public async void Play()
        {
            using (var waveOut = new NAudio.Wave.WaveOutEvent())
            {
                waveOut.Init(reader);
                waveOut.Play();

                await Task.Run(() =>
                {
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                        System.Threading.Thread.Sleep(50);
                });
            }
        }
    }
}