using Gameplay.RulesComposition;
using NUnit.Framework;

public class ScissorRulesTest
{
    [Test]
    public void ScissorRockTest()
    {
        Rule faceoff = new ScissorRockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Rock), typeof(Scissor));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorRockRule)], container.Message);
    }

    public void RockScissorTest()
    {
        Rule faceoff = new ScissorRockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Scissor), typeof(Rock));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorRockRule)], container.Message);
    }

    [Test]
    public void ScissorPaperTest()
    {
        Rule faceoff = new ScissorPaperRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Scissor), typeof(Paper));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorPaperRule)], container.Message);
    }

    [Test]
    public void PaperScissorTest()
    {
        Rule faceoff = new ScissorPaperRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Paper), typeof(Scissor));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorPaperRule)], container.Message);
    }

    [Test]
    public void ScissorLizardTest()
    {
        Rule faceoff = new ScissorLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Scissor), typeof(Lizard));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorLizardRule)], container.Message);
    }

    [Test]
    public void LizardScissorTest()
    {
        Rule faceoff = new ScissorLizardRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Lizard), typeof(Scissor));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorLizardRule)], container.Message);
    }

    [Test]
    public void ScissorSpockRuletest()
    {
        Rule faceoff = new ScissorSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Scissor), typeof(Spock));
        Assert.AreEqual(Result.LOSE, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorSpockRule)], container.Message);
    }
    
    [Test]
    public void SpockScissorTest()
    {
        Rule faceoff = new ScissorSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Spock), typeof(Scissor));
        Assert.AreEqual(Result.WIN, container.Result);
        Assert.AreEqual(CommonStructures.FlavourText[typeof(ScissorSpockRule)], container.Message);
    }

    [Test]
    public void ScissorScissorRuletest()
    {
        Rule faceoff = new ScissorSpockRule(new NoRule());
        ResultContainer container = faceoff.CheckResult(typeof(Scissor), typeof(Scissor));
        Assert.AreEqual(Result.DRAW, container.Result);
        Assert.AreEqual(Constants.DrawMessage, container.Message);
    }
}
