using System;

namespace Gameplay.RulesComposition
{
    public class RockPaperRule : BaseRule
    {
        public RockPaperRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Rock)) && choice2.GetType().Equals(typeof(Paper)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Paper)) && choice2.GetType().Equals(typeof(Rock)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }

    public class RockLizardRule : BaseRule
    {
        public RockLizardRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Rock)) && choice2.GetType().Equals(typeof(Lizard)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Lizard)) && choice2.GetType().Equals(typeof(Rock)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }

    public class RockSpockRule : BaseRule
    {
        public RockSpockRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Rock)) && choice2.GetType().Equals(typeof(Spock)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Spock)) && choice2.GetType().Equals(typeof(Rock)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }
}
