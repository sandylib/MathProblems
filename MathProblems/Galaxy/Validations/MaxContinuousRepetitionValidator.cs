using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathProblems.Galaxy
{
    public class MaxContinuousRepetitionValidator : RuleValidator
    {
        public int MaxRepetitionCount { get; private set; }

        public MaxContinuousRepetitionValidator(int maxRepetitionCount)
        {
            MaxRepetitionCount = maxRepetitionCount;
        }

        public override void Validate(IEnumerable<RomanChart> romanNumber)
        {
            var count = 1;
            var romanNumberArray = romanNumber as RomanChart[] ?? romanNumber.ToArray();
            for (var i = 0; i < romanNumberArray.Count() - 1; i++)
            {
                if (romanNumberArray[i] == romanNumberArray[i + 1])
                    count++;
                if (count > 3)
                    throw new ArgumentException("Cannot Contain more than three continuous repeated characters!");
            }

            if (Successor != null)
                Successor.Validate(romanNumber);
        }
    }
}
