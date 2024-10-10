using NUnit.Framework;
public class CurrentScoreTest
{
    [Test]
    public void Initialisation()
    {
        CurrentScore currentScore = new CurrentScore();
        Assert.IsNotNull(currentScore);
    }

    [Test]
    public void GetCurrentScore()
    {
        CurrentScore currentScore = new CurrentScore();
        Assert.AreEqual(0, currentScore.GetScore());
    }

    [Test]
    public void IncreaseScore()
    {
        CurrentScore currentScore = new CurrentScore();
        currentScore.IncreaseScore();
        Assert.AreEqual(1, currentScore.GetScore());
    }

    [Test]
    public void CustomIncrement()
    {
        CurrentScore currentScore = new CurrentScore();
        currentScore.IncreaseScore(3);
        Assert.AreEqual(3, currentScore.GetScore());
    }

    [Test]
    public void multipleIncrement()
    {
        CurrentScore currentScore = new CurrentScore();
        currentScore.IncreaseScore(3);
        currentScore.IncreaseScore(3);
        Assert.AreEqual(6, currentScore.GetScore());
    }

    [Test]
    public void Reset()
    {
        CurrentScore currentScore = new CurrentScore();
        currentScore.IncreaseScore(3);
        currentScore.IncreaseScore(3);
        currentScore.Reset();
        Assert.AreEqual(0, currentScore.GetScore());
    }

    [Test]
    public void ListenToScoreChange()
    {
        CurrentScore currentScore = new CurrentScore();
        bool listening = false;
        currentScore.AddListener(() => listening = true);
        Assert.IsFalse(listening);

        currentScore.IncreaseScore();
        Assert.IsTrue(listening);
    }

    [Test]
    public void ListenToCustomScoreChanged()
    {
        CurrentScore currentScore = new CurrentScore();
        bool listening = false;
        currentScore.AddListener(() => listening = true);
        Assert.IsFalse(listening);

        currentScore.IncreaseScore(3);
        Assert.IsTrue(listening);
    }
}
