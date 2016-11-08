using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProblems.ConferenceTrackManagement
{
    public class TextFileFormatter : IResultFormatter
    {
        public void Format(IEnumerable<Day> days)
        {
            var tracks = new List<Track>();
            
            using (var streamWriter = new StreamWriter("scheduleReporter.txt"))
            {
                foreach (var day in days)
                {
                    tracks = day.Tracks.ToList();
                    foreach (var track in tracks)
                    {
                        streamWriter.WriteLine("\r\n" + track.MorningSession.Title);
                        var currentTime = track.MorningSession.StartTime;

                        //morning session
                        foreach (var talk in track.MorningSession.Talks)
                        {
                            streamWriter.WriteLine("{0}\t{1}\t{2}{3}", currentTime.ToShortTimeSafe(), talk.Topic,
                                talk.Duration.Value,
                                talk.Duration.Unit);
                            currentTime =
                                currentTime.Add(new TimeSpan(0, talk.Duration.Value * (int)talk.Duration.Unit, 0));
                        }

                        streamWriter.WriteLine("{0}\t{1}\t{2}", track.LunchBreak.Title, track.LunchBreak.StartTime.ToShortTimeSafe(),
                            track.LunchBreak.EndTime.ToShortTimeSafe());

                        streamWriter.WriteLine("\r\n" + track.EveningSession.Title);
                        currentTime = track.EveningSession.StartTime;
                        
                        
                        //evening session
                        foreach (var talk in track.EveningSession.Talks)
                        {
                            streamWriter.WriteLine("{0}\t{1}\t{2}{3}", currentTime.ToShortTimeSafe(), talk.Topic,
                                talk.Duration.Value,
                                talk.Duration.Unit);
                            currentTime =
                                currentTime.Add(new TimeSpan(0, talk.Duration.Value * (int)talk.Duration.Unit, 0));
                        }

                        streamWriter.WriteLine("{0}\t{1}", track.Networking.Title, track.Networking.StartTime.ToShortTimeSafe());
                    }
                }
            }

        }
    }
}
