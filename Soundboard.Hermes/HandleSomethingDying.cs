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
        private static Dictionary<string, Sound> SoundsByType;

        static HandleSomethingDying()
        {
            SoundsByType = new Dictionary<string, Sound>
            {
                ["Willhelm"] = new OggSound("willhelm.ogg"),
                ["Bones01"] = new OggSound("bones tag 01 basic.ogg")
            };
        }

        private readonly Player player;
        private WaveOutEvent wavePlayer;

        public HandleSomethingDying()
        {
            wavePlayer = new WaveOutEvent();

            player = new Player(wavePlayer);
            player.Load(SoundsByType.FirstOrDefault().Value);
        }

        public bool CanHandle(string @event)
        {
            return true;
        }

        public void Handle(string @event)
        {
            player.PlayToCompletion();
        }

        public void Dispose()
        {
            wavePlayer.Dispose();
        }
    }
}
