namespace MathProblems.Galaxy
{
    public class RomanNumberValidationChainManager : IResponsibilityChainManager
    {
        public RuleValidator RuleChainHeader { get; private set; }

        public RomanNumberValidationChainManager(RuleValidator ruleChainHeader)
        {
            RuleChainHeader = ruleChainHeader;
        }

        public void Setup()
        {
            RuleValidator maxRepetitionValidator = new MaxContinuousRepetitionValidator(3);
            RuleValidator subtractionRuleValidator = new SubtractionRuleValidator();
            RuleChainHeader.SetSuccessor(maxRepetitionValidator);
            maxRepetitionValidator.SetSuccessor(subtractionRuleValidator);

        }
    }
}