using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProblems.Trains
{
    public class City
    {
        public char Id { get; set; }

        private Dictionary<City, int> _connections;
        public Dictionary<City, int> Connections => _connections ?? (_connections = new Dictionary<City, int>());

        public City(char id)
        {
            Id = id;
        }
    }
}
