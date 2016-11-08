using System;
using System.Collections.Generic;

namespace MathProblems.ConferenceTrackManagement
{
    public class TalkSession : Slot
    {
        public List<Talk> Talks { get; set; }

        public int _duration;
        public int Duration
        {
            get { return _duration; }
            private set { _duration = (int)EndTime.Subtract(StartTime).TotalMinutes; }
        }

        public TimeSpan TimeRemaining { get; set; }
    }
}
