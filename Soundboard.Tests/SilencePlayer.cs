using System;
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

        public Task Play()
        {
        }

        public void PlayToCompletion()
        {
        }

        public void Stop()
        {
        }

        public PlaybackState CurrentPlaybackState { get; private set; }
    }
}