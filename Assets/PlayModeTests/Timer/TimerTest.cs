using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Gameplay;
using NUnit.Framework;

public class TimerTest
{
    private Timer initialiseTimer()
    {
        MonoBehaviour mono = new MonoBehaviourTest<MonoBehaviourTestStruct>().component;
        Timer timer = new Timer(mono);
        return timer;
    }

    [UnityTest]
    public IEnumerator TimeUpTest()
    {
        Timer timer = initialiseTimer();
        bool timeUp = false;

        timer.AddTimeUpListener(() => timeUp = true);
        timer.StartTimer();
        yield return new WaitForSeconds(Constants.TimeLimit);
        yield return null;
        Assert.IsTrue(timeUp);
    }

    [UnityTest]
    public IEnumerator TimerStoppedTest()
    {
        Timer timer = initialiseTimer();
        bool timeUp = false;
        
        timer.AddTimeUpListener(() => timeUp = true);
        timer.StartTimer();
        yield return new WaitForSeconds(Constants.TimeLimit / 2);
        timer.StopTimer();
        yield return new WaitForSeconds(Constants.TimeLimit / 2);
        yield return null;
        Assert.IsFalse(timeUp);
    }

    [UnityTest]
    public IEnumerator TimerChangedTest() 
    {
        Timer timer = initialiseTimer();
        float timeElasped = 0;

        timer.AddTimerChangedListener(() => timeElasped += Time.deltaTime);
        timer.StartTimer();
        yield return new WaitForSeconds(Constants.TimeLimit);
        Assert.AreEqual(Constants.TimeLimit, timeElasped, 0.01);
    }
}
