namespace Soundboard
{
    public class RecurringSound
    {
        public IPlayer Sound { get; set; }
        public PlaybackFrequency Frequency { get; set; }
    }
}