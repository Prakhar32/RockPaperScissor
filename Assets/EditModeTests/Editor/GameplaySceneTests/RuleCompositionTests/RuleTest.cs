using System;
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
        [Test]
        public void NullTypeCheck()
        {
            Rule faceoff = new NoRule();
            try
            {
                ResultContainer container = faceoff.CheckResult(null, null);
            }
            catch (ArgumentNullException)
            {
                Assert.Pass();
            }    
        }

        [Test]
        public void InvalidTypeCheck()
        {
            Rule faceoff = new NoRule();

            try
            {
                ResultContainer container = faceoff.CheckResult(new Choice(), new Choice());
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(Constants.InvalidTypeArguement, e.Message);
            }
        }

        [Test]
        public void EmptyRuleCheck()
        {
            Rule faceoff = new NoRule();
            try
            {
                ResultContainer container = faceoff.CheckResult(new Rock(), new Paper());
            }
            catch (FormatException e) { 
                Assert.AreEqual(Constants.NoRuleError, e.Message);
            }
        }
    }
}