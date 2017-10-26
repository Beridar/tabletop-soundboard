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
        IEnumerable<IPlayer> RecurringSounds { get; }
    }

    public class Soundscape : ISoundscape
    {
        private readonly IList<IPlayer> backgroundSounds;
        private readonly IList<RecurringSound> recurringSounds;

        public Soundscape()
        {
            recurringSounds = new List<RecurringSound>();
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
            AddRecurringSound(soundPlayer, PlaybackFrequency.OnlyOnDemand);
        }

        public void AddRecurringSound(IPlayer soundPlayer, PlaybackFrequency playbackFrequency)
        {
            recurringSounds.Add(new RecurringSound { Frequency = playbackFrequency, Sound = soundPlayer});
        }

        public IEnumerable<IPlayer> RecurringSounds => recurringSounds.Select(x => x.Sound);
    }
}