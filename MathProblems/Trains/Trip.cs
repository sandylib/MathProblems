using System.Collections.Generic;

namespace MathProblems.Trains
{
    public class Trip
    {
        private IList<City> _cities;

        public IList<City> Cities => _cities ?? (_cities = new List<City>());
    }
}
