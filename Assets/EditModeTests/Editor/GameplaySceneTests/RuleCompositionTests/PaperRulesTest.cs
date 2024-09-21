using Gameplay.RulesComposition;
using NUnit.Framework;

public class PaperRulesTest
{
    [Test]
    public void PaperLizardTest()
    {
        Rule faceoff = new PaperLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Paper(), new Lizard());
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperLizardRule)], container.Message);
    }

    [Test]
    public void LizardPaperTest()
    {
        Rule faceoff = new PaperLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Lizard(), new Paper());
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperLizardRule)], container.Message);
    }

    [Test]
    public void PaperSpockTest()
    {
        Rule faceoff = new PaperSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Paper(), new Spock());
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperSpockRule)], container.Message);
    }

    [Test]
    public void SpockPaperTest()
    {
        Rule faceoff = new PaperSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Spock(), new Paper());
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperSpockRule)], container.Message);
    }

    [Test]
    public void PaperPaperTest()
    {
        Rule faceoff = new PaperSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(new Paper(), new Paper());
        Assert.AreEqual(Result.DRAW, container.Result);
        Assert.AreEqual(Constants.DrawMessage, container.Message);
    }
}
