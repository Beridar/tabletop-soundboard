using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;

namespace Soundboard
{
    public interface ISoundscape
    {
        void AddBackgroundSound(IPlayer theBackgroundSound);
        void Play();
        void Stop();
        void AddRecurringSound(IPlayer soundPlayer);
        void AddRecurringSound(IPlayer soundPlayer, PlaybackFrequency playbackFrequency);
    }

    public class Soundscape : ISoundscape
    {
        private readonly IList<IPlayer> backgroundSounds;
        public IList<IPlayer> RecurringSounds { get; }

        public Soundscape()
        {
            RecurringSounds = new List<IPlayer>();
            backgroundSounds = new List<IPlayer>();
        }

        public PlaybackState CurrentPlaybackState
        {
            get
            {
                return backgroundSounds.Any(x => x.CurrentPlaybackState == PlaybackState.Playing)
                    ? PlaybackState.Playing
                    : PlaybackState.Stopped;
            }
        }

        public void AddBackgroundSound(IPlayer theBackgroundSound)
        {
            backgroundSounds.Add(theBackgroundSound);
        }

        public void Play()
        {
            backgroundSounds
                .GetAnyRandomElement()
                ?.Play();
        }

        public void Stop()
        {
            foreach (var sound in backgroundSounds)
                sound.Stop();
        }

        public void AddRecurringSound(IPlayer soundPlayer)
        {
            RecurringSounds.Add(soundPlayer);
        }

        public void AddRecurringSound(IPlayer soundPlayer, PlaybackFrequency playbackFrequency)
        {
            AddRecurringSound(soundPlayer);
        }
    }
}