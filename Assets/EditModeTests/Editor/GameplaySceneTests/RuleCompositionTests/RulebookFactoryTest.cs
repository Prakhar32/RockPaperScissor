using Gameplay.RulesComposition;
using NUnit.Framework;
public class RulebookFactoryTest
{
    [Test]
    public void RuleBookFactoryNullTest()
    {
        RulebookFactory rulebook = new RulebookFactory();
        Assert.IsNotNull(rulebook.CreateRulebook());
    }

    [Test]
    public void RuleBookFactoryTest() 
    {
        RulebookFactory rulebookFactory = new RulebookFactory();
        Rule rulebook = rulebookFactory.CreateRulebook();
        Assert.AreEqual(Result.LOSE, rulebook.CheckResult(new Rock(), new Paper()).Result);
        Assert.AreEqual(Result.WIN, rulebook.CheckResult(new Paper(), new Spock()).Result);
    }
}
