using Gameplay.RulesComposition;
using NUnit.Framework;
public class SpockRulesTest
{
    [Test]
    public void SpockLizardTest()
    {
        Rule faceoff = new SpockLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Spock), typeof(Lizard));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(SpockLizardRule)], container.Message);
    }

    [Test]
    public void LizardSpockTest()
    {
        Rule faceoff = new SpockLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Lizard), typeof(Spock));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(SpockLizardRule)], container.Message);
    }
}
