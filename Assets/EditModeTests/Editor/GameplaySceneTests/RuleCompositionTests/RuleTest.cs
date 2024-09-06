using System.Collections;
using System.Collections.Generic;
using Gameplay.RulesComposition;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace EidtModeTest.Gameplay.RulesComposition
{
    public class RuleTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NullTypeCheck()
        {
            // Use the Assert class to test conditions
            LogAssert.ignoreFailingMessages = true;
            Rule faceoff = new NoRule();
            ResultContainer container = faceoff.CheckResult(null, null);
            Assert.AreEqual(container.Result, Result.INVALID);
            Assert.AreEqual(container.Message, Constants.NullArguementError);
        }

        [Test]
        public void InvalidTypeCheck()
        {
            // Use the Assert class to test conditions
            LogAssert.ignoreFailingMessages = true;
            Rule faceoff = new NoRule();
            ResultContainer container = faceoff.CheckResult(typeof(Rule), typeof(Rule));
            Assert.AreEqual(container.Result, Result.INVALID);
            Assert.AreEqual(container.Message, Constants.InvalidTypeArguement);
        }

        [Test]
        public void EmptyRuleCheck()
        {
            LogAssert.ignoreFailingMessages = true;
            Rule faceoff = new NoRule();
            ResultContainer container = faceoff.CheckResult(typeof(Rock), typeof(Scissor));
            Assert.AreEqual(container.Result, Result.INVALID);
            Assert.AreEqual(container.Message, Constants.NoRuleError);
        }
    }
}