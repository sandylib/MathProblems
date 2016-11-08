using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathProblems.Trains;

namespace MathProblems
{
    class Program
    {
        static void Main(string[] args)
        {

            RoutesCalculator routesCalculator = new RoutesCalculator();

            var A = new City('A');
            var B = new City('B');
            var C = new City('C');
            var D = new City('D');
            var E = new City('E');

            A.Connections.Add(B, 5);
            B.Connections.Add(C, 4);
            C.Connections.Add(D, 8);
            D.Connections.Add(C, 8);
            D.Connections.Add(E, 6);
            A.Connections.Add(D, 5);
            C.Connections.Add(E, 2);
            E.Connections.Add(B, 3);
            A.Connections.Add(E, 7);

           Console.WriteLine();//routesCalculator.CalculateDistance(A, B, C)
            routesCalculator.CalculateDistance(A, D);
            routesCalculator.CalculateDistance(A, D, C);
            routesCalculator.CalculateDistance(A, E, B, C, D);


        }
    }
}
