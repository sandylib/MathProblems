using System;
using System.Text.RegularExpressions;

namespace MathProblems.ConferenceTrackManagement
{
    public class Talk
    {
        public string Topic { get; private set; }

        public TalkDuration Duration { get; private set; }

        public Talk(string topic, TalkDuration duration)
        {
            try
            {

                Duration = duration;
                if (IsInValidTitle(topic))
                    throw new ArgumentException("Title Cannot contain Numeric values");
                Topic = topic;
            }
            catch (ArgumentException e)
            {
                throw;
            }

        }

        private bool IsInValidTitle(string title)
        {
            return Regex.IsMatch(title, @"[0-9]+$");
        }

    }
}
