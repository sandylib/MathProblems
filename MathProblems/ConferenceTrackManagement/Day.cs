using System.Collections.Generic;

namespace MathProblems.ConferenceTrackManagement
{
    public class Day
    {
        public IEnumerable<Track> Tracks { get; private set; }

        public Day(IEnumerable<Track> tracks)
        {
            Tracks = tracks;
        }
    }
}
