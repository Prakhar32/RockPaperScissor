using UnityEngine;
using UnityEngine.TestTools;

public class MonoBehaviourTestStruct : MonoBehaviour, IMonoBehaviourTest
{
    public bool IsTestFinished
    {
        get { return false; }
    }
}
