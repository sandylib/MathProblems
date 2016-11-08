using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MathProblems.Galaxy
{
    public class CurrencyConvertor
    {
        public Dictionary<RomanChart, string> CurrencyTable { get; private set; }

        public CurrencyConvertor()
        {
            CurrencyTable = new Dictionary<RomanChart, string>();
        }

        public void Evaluate(string expression)
        {
            try
            {
                var tokens = expression.Split(' ');

                var isPresent = tokens.Contains("is", StringComparer.OrdinalIgnoreCase);
                if (!isPresent)
                    throw new ArgumentException("Invalid Expression");

                CurrencyTable.Add((RomanChart)Enum.Parse(typeof(RomanChart), tokens[2].ToString(CultureInfo.InvariantCulture),
                                                          true), tokens[0]);

            }
            catch (ArgumentException e)
            {
                
                throw;
            }


        }

    }
}