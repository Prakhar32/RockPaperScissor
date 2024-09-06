using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.RulesComposition
{
    public abstract class Rule
    {
        protected Rule containingRule;
        public ResultContainer CheckResult(Type option1, Type option2)
        {
            if (!checkForNullValue(option1, option2)) 
                return setContainerContents(Result.INVALID, Constants.NullArguementError);
            if (!checkForTypeMismatch(option1, option2))
                return setContainerContents(Result.INVALID, Constants.InvalidTypeArguement);
            if (areSame(option1, option2))
                return setContainerContents(Result.DRAW, Constants.DrawMessage);

            return compareChoices(option1, option2);
        }

        private bool checkForNullValue(Type option1, Type option2) { 
            return option1 != null && option2 != null;
        }

        private bool checkForTypeMismatch(Type option1, Type option2) { 
            return option1.IsSubclassOf(typeof(Choice)) && option2.IsSubclassOf(typeof(Choice));
        }

        private bool areSame(Type option1, Type option2) { 
            return option1.IsAssignableFrom(option2);
        }

        protected abstract ResultContainer compareChoices(Type option1, Type option2);

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
        protected override ResultContainer compareChoices(Type option1, Type option2)
        {
            return setContainerContents(Result.INVALID, Constants.NoRuleError);
        }
    }
}