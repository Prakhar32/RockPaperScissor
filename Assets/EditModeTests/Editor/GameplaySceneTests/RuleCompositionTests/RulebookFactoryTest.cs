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
        Assert.AreEqual(Result.LOSE, rulebook.CheckResult(typeof(Rock), typeof(Paper)).Result);
        Assert.AreEqual(Result.WIN, rulebook.CheckResult(typeof(Paper), typeof(Spock)).Result);
    }
}
