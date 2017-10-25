using System.Collections;
using System.Collections.Generic;

namespace Soundboard
{
    public interface ISoundscape
    {
    }

    public class Soundscape : ISoundscape
    {
        private IList<IPlayer> backgroundSounds;

        public void AddBackgroundSound(IPlayer theBackgroundSound)
        {
            backgroundSounds.Add(theBackgroundSound);
        }
    }
}