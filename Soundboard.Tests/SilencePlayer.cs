using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard.Tests
{
    public class SilencePlayer : IPlayer
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
                lock (this)
                    CurrentPlaybackState = PlaybackState.Stopped;
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
                CurrentPlaybackState = PlaybackState.Stopped;
        }

        public PlaybackState CurrentPlaybackState { get; private set; }
    }
}