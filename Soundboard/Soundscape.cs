using System.Collections;
using System.Collections.Generic;

namespace Soundboard
{
    public interface ISoundscape
    {
        void AddBackgroundSound(IPlayer theBackgroundSound);
        void Play();
    }

    public class Soundscape : ISoundscape
    {
        private readonly IList<IPlayer> backgroundSounds;

        public Soundscape()
        {
            backgroundSounds = new List<IPlayer>();
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
    }
}