using NUnit.Framework;
using Storage;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class HighScoreDisplayTest
{
    private string highscoreValue;

    [SetUp]
    public void Setuo()
    {
        highscoreValue = PlayerPrefs.GetString(Constants.PlayerPrefsHighScoreKey);
    }

    [UnityTest]
    public IEnumerator TMPTextMissing()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject g = new GameObject();
        HighScoreDisplay display = g.AddComponent<HighScoreDisplay>();
        yield return null;
        Assert.IsTrue(display == null);
    }

    [UnityTest]
    public IEnumerator ComposedSuccessfully()
    {
        GameObject composed = composedObject();
        HighScoreDisplay display = composed.AddComponent<HighScoreDisplay>();
        yield return null;
        Assert.IsFalse(display == null);
    }

    private GameObject composedObject()
    {
        GameObject ob = new GameObject();
        ob.AddComponent<TextMeshProUGUI>();
        return ob;
    }

    //[UnityTest]
    //public IEnumerator SaveHighScoreData()
    //{
    //    GameObject composed = composedObject();
    //    HighScoreDisplay display = composed.AddComponent<HighScoreDisplay>();
    //    yield return null;
    //    display.SaveHighScore();
    //    Assert.IsNotNull(Reader.ReadData(Constants.PlayerPrefsHighScoreKey));
    //}

    [UnityTest]
    public IEnumerator HighScoreLoaded()
    {
        GameObject composed = composedObject();
        HighScoreDisplay display = composed.AddComponent<HighScoreDisplay>();
        yield return null;
        display.LoadHighScore();
        string text = composed.GetComponent<TextMeshProUGUI>().text;
        Assert.AreEqual(Constants.PlayerPrefsHighScoreKey + Reader.ReadData(Constants.PlayerPrefsHighScoreKey), text);
    }

    [TearDown]
    public void TearDown()
    {
        if (!string.IsNullOrEmpty(highscoreValue))
            PlayerPrefs.SetString(Constants.PlayerPrefsHighScoreKey, highscoreValue);
    }
}
