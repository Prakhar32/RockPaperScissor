using Gameplay.RulesComposition;
using NUnit.Framework;
public class RockRulesTest
{
    [Test]
    public void RockPaperTest()
    {
        Rule faceoff = new RockPaperRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Rock(), new Paper());
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockPaperRule)], container.Message);
    }

    [Test]
    public void PaperRockTest()
    {
        Rule faceoff = new RockPaperRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Paper(), new Rock());
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockPaperRule)], container.Message);
    }

    [Test]
    public void RockLizardTest()
    {
        Rule faceoff = new RockLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Rock(), new Lizard());
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockLizardRule)], container.Message);
    }

    [Test]
    public void LizardRockTest()
    {
        Rule faceoff = new RockLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Lizard(), new Rock());
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockLizardRule)], container.Message);
    }

    [Test]
    public void RockSpockTest()
    {
        Rule faceoff = new RockSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Rock(), new Spock());
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockSpockRule)], container.Message);
    }

    [Test]
    public void SpockRockTest()
    {
        Rule faceoff = new RockSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Spock(), new Rock());
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(RockSpockRule)], container.Message);
    }

    [Test]
    public void RockRockTest()
    {
        Rule faceoff = new RockSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Rock(), new Rock());
        Assert.AreEqual(Result.DRAW, container.Result);
        Assert.AreEqual(Constants.DrawMessage, container.Message);
    }
}
