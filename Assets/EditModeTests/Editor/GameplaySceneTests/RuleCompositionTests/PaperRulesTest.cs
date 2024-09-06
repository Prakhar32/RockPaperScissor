using Gameplay.RulesComposition;
using NUnit.Framework;

public class PaperRulesTest
{
    [Test]
    public void PaperLizardTest()
    {
        Rule faceoff = new PaperLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Paper), typeof(Lizard));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperLizardRule)], container.Message);
    }

    [Test]
    public void LizardPaperTest()
    {
        Rule faceoff = new PaperLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Lizard), typeof(Paper));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperLizardRule)], container.Message);
    }

    [Test]
    public void PaperSpockTest()
    {
        Rule faceoff = new PaperSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Paper), typeof(Spock));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperSpockRule)], container.Message);
    }

    [Test]
    public void SpockPaperTest()
    {
        Rule faceoff = new PaperSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Spock), typeof(Paper));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(PaperSpockRule)], container.Message);
    }

    [Test]
    public void PaperPaperTest()
    {
        Rule faceoff = new PaperSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Paper), typeof(Paper));
        Assert.AreEqual(Result.DRAW, container.Result);
        Assert.AreEqual(Constants.DrawMessage, container.Message);
    }
}
