using System;

namespace MathProblems.ConferenceTrackManagement
{
    public static class StringHelper
    {
        public static string ToShortTimeSafe(this TimeSpan timeSpan)
        {
            return new DateTime().Add(timeSpan).ToShortTimeString();
        }
    }
}
