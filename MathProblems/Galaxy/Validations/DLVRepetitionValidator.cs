using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProblems.Galaxy
{
    public class DLVRepetitionValidator : RuleValidator
    {
        public override void Validate(IEnumerable<RomanChart> romanNumber)
        {
            if (romanNumber.Count(x => x == RomanChart.V) > 1)
                throw new ArgumentException("Cannot contain more than one D, L and V!");

            if (romanNumber.Count(x => x == RomanChart.L) > 1)
                throw new ArgumentException("Cannot contain more than one D, L and V!");

            if (romanNumber.Count(x => x == RomanChart.D) > 1)
                throw new ArgumentException("Cannot contain more than one D, L and V!");

            if (Successor != null)
                Successor.Validate(romanNumber);
        }
    }
}
