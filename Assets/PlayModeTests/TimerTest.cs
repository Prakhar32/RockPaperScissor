using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Gameplay;

public class TimerTest
{
    [UnityTest]
    public IEnumerator TimerTestWithEnumeratorPasses()
    {
        GameObject obj = new GameObject();
        Timer timer = obj.AddComponent<Timer>();
        timer.StartTimer();
        yield return new WaitForSeconds(60);
        timer.StopTimer();
    }
}
