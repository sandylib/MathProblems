using System.Collections.Generic;
using System.Linq;

namespace MathProblems.Trains
{
    public class RoutesCalculator
    {
        public string CalculateDistance(params City[] cities)
        {
            int distance = 0;

            for (int i = 0; (i + 1) < cities.Length; i++)
            {
                KeyValuePair<City, int> nextCity = cities[i].Connections.FirstOrDefault(x => x.Key.Id == cities[i + 1].Id);
                if (null != nextCity.Key)
                    distance += nextCity.Value;
                else
                    distance = - 1;
            }

            return distance == -1 ? "NO SUCH ROUTE" : distance.ToString();
        }

        
        public IList<Trip> PossibleTrips(City startCity, City endCity, int numberOfStops)
        {
            IList<Trip> trips = new List<Trip>();
            IList<Trip> possibleTrips = new List<Trip>();

            Queue<City> searchQueue = new Queue<City>();
            searchQueue.Enqueue(startCity);

            int[] lastLevels = new int[numberOfStops + 1];
            int level = 0;
            lastLevels[level] = 1;

            int tripPointer = 0;
            int index = 0;

            trips.Add(new Trip());

            while (searchQueue.Count != 0)
            {
                lastLevels[level]--;
                var current = searchQueue.Dequeue();

                trips[tripPointer].Cities.Add(current);

                if (current.Id == endCity.Id && index > 0)
                {
                    possibleTrips.Add(trips[tripPointer]);
                }

                if ((level + 1) <= numberOfStops)
                {
                    foreach (KeyValuePair<City, int> node in current.Connections)
                    {
                        searchQueue.Enqueue(node.Key);
                    }

                    lastLevels[level + 1] += current.Connections.Count;

                    while (trips.Count < lastLevels[level + 1])
                    {
                        trips.Add(new Trip());
                    }
                }

                tripPointer++;

                if (lastLevels[level] == 0)
                {
                    level++;
                    tripPointer = 0;
                }

                index++;
            }

            return possibleTrips;
        }

        
        public IList<Trip> PossibleTripsWithFixedNumberOfStops(City startCity, City endCity, int numberOfStops)
        {
            IList<Trip> trips = new List<Trip>();
            IList<Trip> possibleTrips = new List<Trip>();

            Queue<City> searchQueue = new Queue<City>();
            searchQueue.Enqueue(startCity);

            int[] lastLevels = new int[numberOfStops + 1];
            int level = 0;
            lastLevels[level] = 1;

            int tripPointer = 0;
            int index = 0;

            trips.Add(new Trip());

            while (searchQueue.Count != 0)
            {
                lastLevels[level]--;
                var current = searchQueue.Dequeue();

                trips[tripPointer].Cities.Add(current);

                if (current.Id == endCity.Id && index > 0 && level == numberOfStops)
                {
                    possibleTrips.Add(trips[tripPointer]);
                }

                if ((level + 1) <= numberOfStops)
                {
                    foreach (KeyValuePair<City, int> node in current.Connections)
                    {
                        searchQueue.Enqueue(node.Key);
                    }

                    lastLevels[level + 1] += current.Connections.Count;

                    while (trips.Count < lastLevels[level + 1])
                    {
                        trips.Add(new Trip());
                    }
                }

                tripPointer++;

                if (lastLevels[level] == 0)
                {
                    level++;
                    tripPointer = 0;
                }

                index++;
            }

            return possibleTrips;
        }
    }
}
