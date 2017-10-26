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
    }

    public class Soundscape : ISoundscape
    {
        private readonly IList<IPlayer> backgroundSounds;

        public Soundscape()
        {
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
            throw new System.NotImplementedException();
        }
    }
}