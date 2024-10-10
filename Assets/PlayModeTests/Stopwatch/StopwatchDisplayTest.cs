using System;
using System.Collections;
using Gameplay;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class StopwatchDisplayTest
{
    [UnityTest]
    public IEnumerator GameobjectMissingImageField()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject parent = new GameObject();
        parent.AddComponent<StopwatchDisplay>();
        yield return null;
        Assert.IsNull(parent.GetComponent<StopwatchDisplay>());
    }

    [UnityTest]
    public IEnumerator GameobjectMissingTextField()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject parent = createGameoBjectWithImage();
        parent.AddComponent<StopwatchDisplay>();
        yield return null;
        Assert.IsNull (parent.GetComponent<StopwatchDisplay>());
    }

    [UnityTest]
    public IEnumerator GameObjectMissingSprite()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject timerGameObject = creategameobjectWithoutSprite();
        timerGameObject.AddComponent<StopwatchDisplay>();
        yield return null;
        Assert.IsNull(timerGameObject.GetComponent<StopwatchDisplay>());
    }

    [UnityTest]
    public IEnumerator MissingTimer()
    {
        LogAssert.ignoreFailingMessages = true;
        GameObject timerGameObject = composeTimerGameObject();
        timerGameObject.AddComponent<StopwatchDisplay>();
        yield return null;
        Assert.IsTrue(timerGameObject.GetComponent<StopwatchDisplay>() == null);
    }

    [UnityTest]
    public IEnumerator DisplayComposedSuccessfully()
    {
        GameObject timerGameObject = composeTimerGameObject();
        StopwatchDisplay display = timerGameObject.AddComponent<StopwatchDisplay>();
        display.InitialiseDisplay(getStopwatchStub());
        yield return null;
        Assert.IsFalse(timerGameObject.GetComponent<StopwatchDisplay>() == null);
    }

    [UnityTest]
    public IEnumerator DisplayWorkingWithStub()
    {
        GameObject timerGameObject = composeTimerGameObject();
        timerGameObject.AddComponent<StopwatchDisplay>();
        Stopwatch timer = getStopwatchStub();
        StopwatchDisplay display = timerGameObject.GetComponent<StopwatchDisplay>();
        display.InitialiseDisplay(timer);
        yield return null;

        timer.StartTimer();
        yield return null;
        string displayedText = timerGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        string expectedText = TimeSpan.FromSeconds(timer.GetTime() + 1).Seconds.ToString();
        Assert.AreEqual(expectedText, displayedText);
    }

    [UnityTest]
    public IEnumerator DisplayWorkingWithTimer()
    {
        GameObject timerGameObject = composeTimerGameObject();
        timerGameObject.AddComponent<StopwatchDisplay>();
        Stopwatch timer = initialiseTimer();
        StopwatchDisplay display = timerGameObject.GetComponent<StopwatchDisplay>();
        display.InitialiseDisplay(timer);
        yield return null;

        float timeLeft = Constants.TimeLimit;
        timer.StartTimer();
        yield return null;
        
        while(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            string displayedText = timerGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            string expectedText = TimeSpan.FromSeconds(timer.GetTime() + 1).Seconds.ToString();
            Assert.AreEqual(expectedText, displayedText);
            yield return null;
        }
    }

    private Stopwatch initialiseTimer()
    {
        MonoBehaviour mono = new MonoBehaviourTest<MonoBehaviourTestStruct>().component;
        Stopwatch timer = new MonobehaviourStopwatch(mono);
        return timer;
    }

    private Stopwatch getStopwatchStub()
    {
        StopwatchStub stub = new StopwatchStub();
        return stub;
    }

    private GameObject createGameoBjectWithImage()
    {
        GameObject gameobjectWithImage = new GameObject();
        gameobjectWithImage.AddComponent<Image>();
        return gameobjectWithImage;
    }

    private GameObject addTextFieldInChild(GameObject parent) 
    {
        GameObject child = new GameObject();
        child.transform.parent = parent.transform;
        child.AddComponent<TextMeshProUGUI>();
        return parent;
    }

    private GameObject creategameobjectWithoutSprite()
    {
        GameObject parent = createGameoBjectWithImage();
        parent = addTextFieldInChild(parent);
        return parent;
    }

    private GameObject createGameobjectWithFilledImage()
    {
        GameObject gameobjectWithFilledImage = createGameoBjectWithImage();
        Sprite sprite = Sprite.Create(createTexture(), new Rect(0, 0, 2, 2), Vector2.zero);
        gameobjectWithFilledImage.GetComponent<Image>().sprite = sprite;
        gameobjectWithFilledImage.GetComponent <Image>().type = Image.Type.Filled;
        return gameobjectWithFilledImage;
    }

    private Texture2D createTexture()
    {
        var texture = new Texture2D(2, 2, TextureFormat.ARGB32, false);

        // set the pixel values
        texture.SetPixel(0, 0, new Color(1.0f, 1.0f, 1.0f, 0.5f));
        texture.SetPixel(1, 0, Color.clear);
        texture.SetPixel(0, 1, Color.white);
        texture.SetPixel(1, 1, Color.black);

        // Apply all SetPixel calls
        texture.Apply();
        return texture;
    }

    private GameObject composeTimerGameObject() 
    {
        GameObject parent = createGameobjectWithFilledImage();
        parent = addTextFieldInChild(parent);
        return parent;
    }

    class StopwatchStub : Stopwatch
    {
        private UnityEvent changedEvent;

        public StopwatchStub()
        {
            changedEvent = new UnityEvent();
        }

        public void AddTimerChangedListener(UnityAction subscriber)
        {
            changedEvent.AddListener(subscriber);
        }

        public void AddTimeUpListener(UnityAction subscriber)
        {
            
        }

        public float GetTime()
        {
            return 3;
        }

        public void RemoveTimerChangedListener(UnityAction subscriber)
        {
            changedEvent.RemoveListener(subscriber);
        }

        public void RemoveTimeUpListener(UnityAction subscriber)
        {
            
        }

        public void StartTimer()
        {
            changedEvent.Invoke();
        }

        public void StopTimer()
        {
            
        }
    }
}
