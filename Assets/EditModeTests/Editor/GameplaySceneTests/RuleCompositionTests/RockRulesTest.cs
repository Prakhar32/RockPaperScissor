using Gameplay.RulesComposition;
using NUnit.Framework;
public class RockRulesTest
{
    [Test]
    public void RockPaperTest()
    {
        Rule faceoff = new RockPaperRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Rock), typeof(Paper));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockPaperRule)], container.Message);
    }

    [Test]
    public void PaperRockTest()
    {
        Rule faceoff = new RockPaperRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Paper), typeof(Rock));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockPaperRule)], container.Message);
    }

    [Test]
    public void RockLizardTest()
    {
        Rule faceoff = new RockLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Rock), typeof(Lizard));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockLizardRule)], container.Message);
    }

    [Test]
    public void LizardRockTest()
    {
        Rule faceoff = new RockLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Lizard), typeof(Rock));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockLizardRule)], container.Message);
    }

    [Test]
    public void RockSpockTest()
    {
        Rule faceoff = new RockSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Rock), typeof(Spock));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockSpockRule)], container.Message);
    }

    [Test]
    public void SpockRockTest()
    {
        Rule faceoff = new RockSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Spock), typeof(Rock));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockSpockRule)], container.Message);
    }

    [Test]
    public void RockRockTest()
    {
        Rule faceoff = new RockSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Rock), typeof(Rock));
        Assert.AreEqual(Result.DRAW, container.Result);
        Assert.AreEqual(Constants.DrawMessage, container.Message);
    }
}
