using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface IPlayer
    {
        Task Play();
        void PlayToCompletion();
        void Stop();
        PlaybackState CurrentPlaybackState { get; }
    }
}