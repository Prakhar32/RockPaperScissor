using System;

namespace Gameplay.RulesComposition
{
    public class ScissorRockRule : BaseRule
    {
        public ScissorRockRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Rock)) && choice2.GetType().Equals(typeof(Scissor)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Scissor)) && choice2.GetType().Equals(typeof(Rock)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }

    public class ScissorPaperRule : BaseRule
    {
        public ScissorPaperRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Paper)) && choice2.GetType().Equals(typeof(Scissor)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Scissor)) && choice2.GetType().Equals(typeof(Paper)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }

    public class ScissorLizardRule : BaseRule
    {
        public ScissorLizardRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Lizard)) && choice2.GetType().Equals(typeof(Scissor)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Scissor)) && choice2.GetType().Equals(typeof(Lizard)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            
            return containingRule.CheckResult(choice1, choice2);
        }
    }

    public class ScissorSpockRule : BaseRule
    {
        public ScissorSpockRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            if (choice1.GetType().Equals(typeof(Spock)) && choice2.GetType().Equals(typeof(Scissor)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            else if (choice1.GetType().Equals(typeof(Scissor)) && choice2.GetType().Equals(typeof(Spock)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(choice1, choice2);
        }
    }
}