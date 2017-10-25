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
        private IList<IPlayer> backgroundSounds;

        public void AddBackgroundSound(IPlayer theBackgroundSound)
        {
            backgroundSounds.Add(theBackgroundSound);
        }

        public void Play()
        {
            throw new System.NotImplementedException();
        }
    }
}