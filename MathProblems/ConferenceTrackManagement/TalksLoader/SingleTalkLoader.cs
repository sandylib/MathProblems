using System.Collections.Generic;

namespace MathProblems.ConferenceTrackManagement
{
    public class SingleTalkLoader : ITalksLoader
    {
        private Talk _talk;

        public SingleTalkLoader(Talk talk)
        {
            _talk = talk;
        }

        public IEnumerable<Talk> Load()
        {
            return new List<Talk>(){
                _talk
            };
        }
    }
}
