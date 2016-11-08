using System.Collections.Generic;

namespace MathProblems.ConferenceTrackManagement
{
    public interface IScheduler
    {
        void Schedule(IEnumerable<Day> days, IEnumerable<Talk> talks);
    }
}