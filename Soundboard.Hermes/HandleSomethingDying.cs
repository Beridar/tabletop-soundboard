using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soundboard;

namespace Soundboard.Hermes
{
    class HandleSomethingDying : IEventHandler
    {
        private static Dictionary<string, Sound> SoundsByType;
        private static WaveOutEvent WavePlayer;

        static HandleSomethingDying()
        {
            SoundsByType = new Dictionary<string, Sound>
            {
                ["Willhelm"] = new OggSound("willhelm.ogg"),
                ["Bones01"] = new OggSound("bones tag 01 basic.ogg")
            };

            WavePlayer = new WaveOutEvent();
        }

        private readonly Player player;

        public HandleSomethingDying()
        {
            player = new Player(WavePlayer);

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
    }
}
