using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soundboard;

namespace Soundboard.Hermes
{
    class HandleSomethingDying : IEventHandler, IDisposable
    {
        public bool CanHandle(string @event)
        {
            return true;
        }

        public void Handle(string @event)
        {
            using (var output = new WaveOutEvent())
            using (var sound = new Player(output))
            using (var wilhelm = new OggSound("willhelm.ogg"))
            {
                sound.Load(wilhelm);
                sound.PlayToCompletion();
            }
        }

        public void Dispose()
        {
        }
    }
}
