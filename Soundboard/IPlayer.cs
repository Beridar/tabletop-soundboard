using System;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IPlayer : IDisposable
    {
        void LoadFile(string filename);
        Task Play();
        void PlayToCompletion();
        void Stop();
        PlaybackState CurrentPlaybackState { get; }
    }

    public abstract class Player : IPlayer
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public abstract void LoadFile(string filename);

        public Task Play()
        {
            throw new NotImplementedException();
        }

        public void PlayToCompletion()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public PlaybackState CurrentPlaybackState { get; }
    }
}