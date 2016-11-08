using System.Collections.Generic;

namespace MathProblems.Galaxy
{
    public abstract class RuleValidator
    {
        protected RuleValidator Successor;

        public void SetSuccessor(RuleValidator successor)
        {
            this.Successor = successor;
        }

        public abstract void Validate(IEnumerable<RomanChart> romanNumber);
    }
}
