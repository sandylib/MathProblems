using MathProblems.Trains;
using NUnit.Framework;

namespace MathProblems.Tests
{
    [TestFixture, Category("Train")]
    public class TrainsRoutesCalculatorTest
    {
        [Test]
        public void CalculateDistance_with_a_valid_route_should_return_the_distance()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue("9" == routesCalculator.CalculateDistance(A, B, C));
            Assert.IsTrue("5" == routesCalculator.CalculateDistance(A, D));
            Assert.IsTrue("13" == routesCalculator.CalculateDistance(A, D, C));
            Assert.IsTrue("22" == routesCalculator.CalculateDistance(A, E, B, C, D));
        }

        [Test]
        public void CalculateDistance_with_a_invalid_route_should_return_negative()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue("NO SUCH ROUTE" == routesCalculator.CalculateDistance(A, E, D));
        }

        [Test]
        public void PossibleTrips_should_return_the_trips_between_two_cities()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue(2 == routesCalculator.PossibleTrips(C, C, 3).Count);
            Assert.IsTrue(3 == routesCalculator.PossibleTrips(A, C, 3).Count);
            Assert.IsTrue(6 == routesCalculator.PossibleTrips(A, C, 4).Count);
            Assert.IsTrue(3 == routesCalculator.PossibleTrips(D, C, 3).Count);
            Assert.IsTrue(1 == routesCalculator.PossibleTrips(E, B, 1).Count);
            Assert.IsTrue(2 == routesCalculator.PossibleTrips(E, C, 4).Count);
        }

        [Test]
        public void PossibleTripsWithFixedNumberOfStops_should_return_the_trips_between_two_cities_with_exactly_informed_number_of_stops()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

            Assert.IsTrue(3 == routesCalculator.PossibleTripsWithFixedNumberOfStops(A, C, 4).Count);
        }
    }
}
