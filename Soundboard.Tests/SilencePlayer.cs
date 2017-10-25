using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard.Tests
{
    internal class SilencePlayer : IPlayer
    {
        public void Dispose()
        {
        }

        public void LoadFile(string filename)
        {
        }

        public async Task Play()
        {
            lock (this)
                CurrentPlaybackState = PlaybackState.Playing;

            await Task.Run(() =>
            {
                Thread.Sleep(500);
            });
        }

        public void PlayToCompletion()
        {
            while (CurrentPlaybackState == PlaybackState.Playing)
                Thread.Sleep(50);
        }

        public void Stop()
        {
            lock (this)
                CurrentPlaybackState = PlaybackState.Paused;
        }

        public PlaybackState CurrentPlaybackState { get; private set; }
    }
}