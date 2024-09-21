using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.RulesComposition
{
    public abstract class Rule
    {
        protected Rule containingRule;
        public ResultContainer CheckResult(Choice choice1, Choice choice2)
        {
            if (checkForNullValue(choice1, choice2))
                throw new ArgumentNullException();
            if (checkForTypeMismatch(choice1, choice2))
                throw new ArgumentException(Constants.InvalidTypeArguement);
            if (areSame(choice1, choice2))
                return setContainerContents(Result.DRAW, Constants.DrawMessage);

            return compareChoices(choice1, choice2);
        }

        private bool checkForNullValue(Choice option1, Choice option2) { 
            return option1 == null || option2 == null;
        }

        private bool checkForTypeMismatch(Choice option1, Choice option2) { 
            return !option1.GetType().IsSubclassOf(typeof(Choice)) || !option2.GetType().IsSubclassOf(typeof(Choice));
        }

        private bool areSame(Choice option1, Choice option2) { 
            return option1.GetType().Equals(option2.GetType());
        }

        protected abstract ResultContainer compareChoices(Choice choice1, Choice choice2);

        protected ResultContainer setContainerContents(Result result, string message)
        {
            ResultContainer resultContainer = ResultContainer.getInstance();
            resultContainer.Message = message;
            resultContainer.Result = result;
            return resultContainer;
        }
        protected void setContainingRule(Rule faceoff) {  containingRule = faceoff;}
    }

    public abstract class BaseRule : Rule {
        public BaseRule(Rule rule) { 
            setContainingRule(rule);
        }
    }

    public class NoRule : Rule
    {
        protected override ResultContainer compareChoices(Choice choice1, Choice choice2)
        {
            throw new FormatException(Constants.NoRuleError);
        }
    }
}