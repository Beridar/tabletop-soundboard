using System;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard.Tests
{
    public class SilencePlayer : IPlayer
    {
        public virtual void Dispose()
        {
        }

        public virtual void LoadFile(string filename)
        {
        }

        public virtual async Task Play()
        {
            lock (this)
                CurrentPlaybackState = PlaybackState.Playing;

            await Task.Run(() =>
            {
                Thread.Sleep(500);
            });
        }

        public virtual void PlayToCompletion()
        {
            while (CurrentPlaybackState == PlaybackState.Playing)
                Thread.Sleep(50);
        }

        public virtual void Stop()
        {
            lock (this)
                CurrentPlaybackState = PlaybackState.Paused;
        }

        public PlaybackState CurrentPlaybackState { get; private set; }
    }
}