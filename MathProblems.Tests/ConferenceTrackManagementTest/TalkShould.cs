using MathProblems.ConferenceTrackManagement;
using NUnit.Framework;

namespace MathProblems.Tests
{
    [TestFixture, Category("ConferenceTrack")]
    public class TalkShould
    {
        private Talk _testTalk;
        private TalkDuration _duration;
        [SetUp]
        public void Initialize()
        {
            _duration = new TalkDuration(TimeUnit.Min, 60);
            _testTalk = new Talk("Topic", _duration);
        }

        [Test]
        [ExpectedException]
        public void ThrowExceptionIfTitleContainsNumbers()
        {
            _testTalk = new Talk("Topic1", _duration);
        }

        [Test]
        [ExpectedException]
        public void ThrowExceptionForInvalidDuration()
        {
            _duration = new TalkDuration(TimeUnit.Min, -10);
            _testTalk = new Talk("Topic", _duration);
        }

    }
}
