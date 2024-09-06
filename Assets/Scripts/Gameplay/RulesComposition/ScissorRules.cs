using System;

namespace Gameplay.RulesComposition
{
    public class ScissorRockRule : BaseRule
    {
        public ScissorRockRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Type option1, Type option2)
        {
            if (option1.IsAssignableFrom(typeof(Rock)) && option2.IsAssignableFrom(typeof(Scissor)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            else if (option1.IsAssignableFrom(typeof(Scissor)) && option2.IsAssignableFrom(typeof(Rock)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(option1, option2);
        }
    }

    public class ScissorPaperRule : BaseRule
    {
        public ScissorPaperRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Type option1, Type option2)
        {
            if (option1.IsAssignableFrom(typeof(Paper)) && option2.IsAssignableFrom(typeof(Scissor)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);
            else if (option1.IsAssignableFrom(typeof(Scissor)) && option2.IsAssignableFrom(typeof(Paper)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(option1, option2);
        }
    }

    public class ScissorLizardRule : BaseRule
    {
        public ScissorLizardRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Type option1, Type option2)
        {
            if (option1.IsAssignableFrom(typeof(Lizard)) && option2.IsAssignableFrom(typeof(Scissor)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);
            else if (option1.IsAssignableFrom(typeof(Scissor)) && option2.IsAssignableFrom(typeof(Lizard)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            
            return containingRule.CheckResult(option1, option2);
        }
    }

    public class ScissorSpockRule : BaseRule
    {
        public ScissorSpockRule(Rule rule) : base(rule)
        {
        }

        protected override ResultContainer compareChoices(Type option1, Type option2)
        {
            if (option1.IsAssignableFrom(typeof(Spock)) && option2.IsAssignableFrom(typeof(Scissor)))
                return setContainerContents(Result.WIN, CommonStructures.FlavourText[GetType()]);
            else if (option1.IsAssignableFrom(typeof(Scissor)) && option2.IsAssignableFrom(typeof(Spock)))
                return setContainerContents(Result.LOSE, CommonStructures.FlavourText[GetType()]);

            return containingRule.CheckResult(option1, option2);
        }
    }
}