﻿using System.Collections.Generic;
using System.Linq;
using MathProblems.ConferenceTrackManagement;
using NUnit.Framework;

namespace MathProblems.Tests
{
    [TestFixture,Category("ConferenceTrack")]
    public class ConferenceTrackManagerShould
    {
        private Conference _testConference;
        private TalkDuration _duration;
        private IScheduler _scheduler;
        private List<Track> _tracks;
        private List<Day> _days;

        [SetUp]
        public void Initialize()
        {
            _duration = new TalkDuration(TimeUnit.Min, 60);
            _scheduler = new SimpleScheduler();
            SetDaysSchedule();
            _testConference = new Conference(_scheduler, _days);
            _testConference.ResultFormatter = new TextFileFormatter();
        }

        [TearDown]
        public void CleanUp()
        {
            _testConference = null;
        }

        [Test]
        public void DoNothing()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void ReturnZeroIfNoTalksRegistered()
        {
            Assert.AreEqual(_testConference.TotalTalks, 0);
        }

        [Test]
        public void ReturnOneIfOneTalkRegistered()
        {

            Talk testTalk = new Talk("test Topic", _duration);

            _testConference.TalksLoader = new SingleTalkLoader(testTalk);
            _testConference.RegisterTalks();

            Assert.AreEqual(_testConference.TotalTalks, 1);
        }

        [Test]
        public void RegisterTheTalkProperly()
        {
            Talk testTalk = new Talk("test Topic", _duration);

            _testConference.TalksLoader = new SingleTalkLoader(testTalk);
            _testConference.RegisterTalks();
            Talk registerTestTalk = _testConference.GetTalkByName("test Topic");

            Assert.AreEqual(testTalk.Topic, registerTestTalk.Topic);
            Assert.AreEqual(_testConference.TotalTalks, 1);
            Assert.AreEqual(testTalk.Duration, registerTestTalk.Duration);
        }

        [Test]
        public void RegisterLightningTalks()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetLightningTalksList());
            _testConference.RegisterTalks();
        }

        [Test]
        public void RegisterMultipleTalksProperly()
        {
            var testTalk1 = new Talk("TopicOne", _duration);
            var testTalk2 = new Talk("TopicTwo", _duration);
            var testTalk3 = new Talk("TopicThree", _duration);

            _testConference.TalksLoader = new SingleTalkLoader(testTalk1);
            _testConference.RegisterTalks();
            _testConference.TalksLoader = new SingleTalkLoader(testTalk2);
            _testConference.RegisterTalks();
            _testConference.TalksLoader = new SingleTalkLoader(testTalk3);
            _testConference.RegisterTalks();


            var registeredTalk = _testConference.GetTalkByName("TopicOne");

            Assert.AreEqual(_testConference.TotalTalks, 3);
            Assert.AreEqual(testTalk1.Topic, registeredTalk.Topic);
        }

        [Test]
        public void ReturnNullIfTalkIsNotRegistered()
        {
            Talk testTalk1 = new Talk("TopicOne", _duration);
            _testConference.TalksLoader = new SingleTalkLoader(testTalk1);
            _testConference.RegisterTalks();

            var registeredTalk = _testConference.GetTalkByName("TopicTwo");

            Assert.AreEqual(_testConference.TotalTalks, 1);
            Assert.AreEqual(null, registeredTalk);
        }

        [Test]
        [ExpectedException]
        public void NotRegisterTalksIfItCannotBeScheduled()
        {
            _testConference = new Conference(_scheduler, new List<Day>(){ new Day( new List<Track>(){
                                                                            ConferenceTrackDataSeed.GetNewTrack()
                                                                          })});

            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();

        }

        [Test]
        public void BeAbleToImportTalksList()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();
            Assert.AreEqual(_testConference.TotalTalks, 13);
        }

        [Test]
        public void AddTalksIfTheyWereAddedInTwoTurns()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();

            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListTwo());
            _testConference.RegisterTalks();

            Assert.AreEqual(19, _testConference.TotalTalks);
        }

        [Test]
        public void ScheduleTalks()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();

            _testConference.Schedule();
        }

        [Test]
        public void AlsoScheduleTalksWithNetworkingEvent()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();

            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListTwo());
            _testConference.RegisterTalks();

            _testConference.Schedule();
        }

        [Test]
        public void ScheduleAllTheTalksRegistered()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();

            _testConference.Schedule();

            Assert.AreEqual(13, GetScheduledTalks());
        }

        [Test]
        public void ScheduleIfTalksWereRegisteredInIterations()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();

            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListTwo());
            _testConference.RegisterTalks();

            _testConference.Schedule();
            Assert.AreEqual(19, GetScheduledTalks());
        }

        [Test]
        public void WriteResultToTextFile()
        {
            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListOne());
            _testConference.RegisterTalks();

            _testConference.TalksLoader = new FileTalksLoader(ConferenceTrackDataSeed.GetTalksListTwo());
            _testConference.RegisterTalks();

            _testConference.Schedule();

            _testConference.GetSchedule();
        }


        private int GetScheduledTalks()
        {
            return _testConference.Days.Sum(day => day.Tracks.Sum(track => track.EveningSession.Talks.Count + track.MorningSession.Talks.Count));
        }

        private void SetDaysSchedule()
        {
            _days = new List<Day>();

            _tracks = new List<Track>();
            for (var i = 0; i < 2; i++)
            {
                _tracks.Add(ConferenceTrackDataSeed.GetNewTrack());
            }

            _days.Add(new Day(_tracks));
        }
    }
}
