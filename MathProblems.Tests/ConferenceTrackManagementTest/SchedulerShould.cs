using MathProblems.ConferenceTrackManagement;
using NUnit.Framework;

namespace MathProblems.Tests
{
    [TestFixture, Category("ConferenceTrack")]
    public class SchedulerShould
    {
        [Test]
        [ExpectedException]
        public void ThrowExceptionWhenNullTracksWerePassed()
        {
            var scheduler = new SimpleScheduler();
            scheduler.Schedule(null, null);
        }
    }
}
