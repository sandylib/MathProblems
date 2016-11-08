namespace MathProblems.ConferenceTrackManagement
{
    public class Track
    {
        public string Title { get; private set; }

        public TalkSession MorningSession { get; set; }

        public Break LunchBreak { get; set; }

        public TalkSession EveningSession { get; set; }

        public NetworkingEvent Networking { get; set; }
    }
}
