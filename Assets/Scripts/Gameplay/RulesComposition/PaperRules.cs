using System;

namespace Gameplay.RulesComposition
{
    public class PaperSpockRule : BaseRule
    {
        public PaperSpockRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Paper)) && choice2.GetType().Equals(typeof(Spock)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Spock)) && choice2.GetType().Equals(typeof(Paper)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }

    public class PaperLizardRule : BaseRule
    {
        public PaperLizardRule(Rule rule) : base(rule)
        {
        }
        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Paper)) && choice2.GetType().Equals(typeof(Lizard)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Lizard)) && choice2.GetType().Equals(typeof(Paper)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }
}
