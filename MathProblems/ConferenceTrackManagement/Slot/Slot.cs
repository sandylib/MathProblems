using System;

namespace MathProblems.ConferenceTrackManagement
{
    public abstract class Slot
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string Title { get; set; }
    }
}
