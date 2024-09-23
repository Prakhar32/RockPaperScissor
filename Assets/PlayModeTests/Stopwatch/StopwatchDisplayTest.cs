using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class StopwatchDisplayTest
{
    private Stopwatch initialiseTimer()
    {
        MonoBehaviour mono = new MonoBehaviourTest<MonoBehaviourTestStruct>().component;
        Stopwatch timer = new MonobehaviourStopwatch(mono);
        return timer;
    }

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
        yield return null;
        Assert.IsNull(timerGameObject.GetComponent<StopwatchDisplay>());
    }

    [UnityTest]
    public IEnumerator GameobjectSuccessfullyComposed()
    {
        GameObject timerGameObject = composeTimerGameObject();
        yield return null;
        Assert.IsNotNull(timerGameObject.GetComponent<StopwatchDisplay>());
    }

    [UnityTest]
    public IEnumerator TimerWorking()
    {
        GameObject timerGameObject = composeTimerGameObject();
        yield return null;
        Stopwatch timer = initialiseTimer();

        StopwatchDisplay display = timerGameObject.GetComponent<StopwatchDisplay>();
        display.InitialiseDisplay(timer);
        yield return null;

        bool timeUp = false;
        timer.AddTimeUpListener(() => timeUp = true);
        timer.StartTimer();
        yield return new WaitForSeconds(Constants.TimeLimit);
        Assert.IsTrue(timeUp);
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
        parent.AddComponent<StopwatchDisplay>();
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
        parent.AddComponent<StopwatchDisplay>();
        return parent;
    }
}
