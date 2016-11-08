using System.Collections.Generic;

namespace MathProblems.ConferenceTrackManagement
{
    public interface IResultFormatter
    {
        void Format(IEnumerable<Day> days);
    }
}