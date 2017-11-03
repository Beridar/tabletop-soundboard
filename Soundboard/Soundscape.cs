using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Soundboard
{
    public interface ISoundscape
    {
        void AddBackgroundSound(IPlayer theBackgroundSound);
        void Play();
        void Stop();
        void AddRecurringSound(ISound soundPlayer);
        void AddRecurringSound(ISound soundPlayer, PlaybackFrequency playbackFrequency);
        IEnumerable<IPlayer> RecurringSounds { get; }
    }

    public class Soundscape : ISoundscape
    {
        private readonly IPlayer player;
        private readonly IList<ISound> backgroundSounds;
        private readonly IList<RecurringSound> recurringSounds;
        private readonly CancellationTokenSource stopWorkersSource;

        public Soundscape() : this(new Player())
        {
        }

        public Soundscape(IPlayer player)
        {
            this.player = player;
            recurringSounds = new List<RecurringSound>();
            backgroundSounds = new List<ISound>();
            stopWorkersSource = new CancellationTokenSource();
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
            var anyBackgroundSound = backgroundSounds
                .GetAnyRandomElement();

            player.Play(anyBackgroundSound);

            foreach (var recurring in recurringSounds.Where(x => x.Frequency == PlaybackFrequency.LoopIndefinitely))
                player.Play(recurring.Sound);
        }

        public void Stop()
        {
            player.Stop();
        }

        public void AddRecurringSound(ISound soundPlayer)
        {
            AddRecurringSound(soundPlayer, PlaybackFrequency.OnlyOnDemand);
        }

        public void AddRecurringSound(ISound soundPlayer, PlaybackFrequency playbackFrequency)
        {
            recurringSounds.Add(new RecurringSound { Frequency = playbackFrequency, Sound = soundPlayer});
        }

        public IEnumerable<IPlayer> RecurringSounds => recurringSounds.Select(x => x.Sound);
    }
}