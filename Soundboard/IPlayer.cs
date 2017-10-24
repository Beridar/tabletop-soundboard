using System;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IPlayer : IDisposable
    {
        Task Play();
        void PlayToCompletion();
        void Stop();
        PlaybackState CurrentPlaybackState { get; }
    }
}