using System;

namespace MathProblems.ConferenceTrackManagement
{
    public class NetworkingEvent : Slot
    {
        public TimeSpan StartTimeFrom { get; set; }

        public TimeSpan StartTimeTo { get; set; }
    }
}
