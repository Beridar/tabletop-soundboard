namespace Soundboard
{
    public class RecurringSound
    {
        public ISound Sound { get; set; }
        public PlaybackFrequency Frequency { get; set; }
    }
}