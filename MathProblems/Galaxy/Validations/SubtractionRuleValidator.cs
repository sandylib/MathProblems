using System;
using System.Collections.Generic;
using System.Linq;

namespace MathProblems.Galaxy
{
    public class SubtractionRuleValidator : RuleValidator
    {

        public override void Validate(IEnumerable<RomanChart> romanNumber)
        {
            var romanNumberArray = romanNumber as RomanChart[] ?? romanNumber.ToArray();
            for (var i = 0; i < romanNumberArray.Count(); i++)
            {
                if (i < romanNumberArray.Count() - 1)
                {
                    var value = (int)romanNumberArray[i + 1] / (int)romanNumberArray[i];
                    if (value > 10)
                        throw new ArgumentException("Subtraction rule violated!");
                }
            }

            if (Successor != null)
                Successor.Validate(romanNumber);
        }
    }
}
