using System.Collections.Generic;

namespace MathProblems.ConferenceTrackManagement
{
    public interface ITalksLoader
    {
        IEnumerable<Talk> Load();
    }
}