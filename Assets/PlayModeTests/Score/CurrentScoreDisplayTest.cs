using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class CurrentScoreDisplayTest
{
    [UnityTest]
    public IEnumerator MissingTextField()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        CurrentScoreDisplay display = g.AddComponent<CurrentScoreDisplay>();
        yield return null;
        Assert.IsTrue(display == null);
    }

    [UnityTest]
    public IEnumerator MissingScoreField()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        g.AddComponent<TextMeshProUGUI>();
        g.AddComponent<CurrentScoreDisplay>();
        CurrentScoreDisplay display = g.GetComponent<CurrentScoreDisplay>();
        yield return null;
        Assert.IsTrue(display == null);
    }

    [UnityTest]
    public IEnumerator CorrectInitialisation()
    {
        CurrentScore currentScore = new CurrentScore();
        GameObject g = composeDisplayGameobject();
        CurrentScoreDisplay display = g.AddComponent<CurrentScoreDisplay>();
        display.Initialise(currentScore);
        yield return null;
        Assert.IsFalse(display == null);
    }

    private GameObject composeDisplayGameobject()
    {
        GameObject g = new GameObject();
        g.AddComponent<TextMeshProUGUI>();
        return g;
    }

    [UnityTest]
    public IEnumerator KeepTrackOfCurrentScore()
    {
        CurrentScore score = new CurrentScore();
        GameObject g = composeDisplayGameobject();
        CurrentScoreDisplay display = g.AddComponent<CurrentScoreDisplay>();
        display.Initialise(score);
        yield return new WaitForSeconds(4);

        string displayedtext = g.GetComponent<TextMeshProUGUI>().text;
        Assert.AreEqual("Score : " + score.GetScore(), displayedtext);

        score.IncreaseScore();
        displayedtext = g.GetComponent<TextMeshProUGUI>().text;
        Assert.AreEqual("Score : " + score.GetScore(), displayedtext);
    }
}
