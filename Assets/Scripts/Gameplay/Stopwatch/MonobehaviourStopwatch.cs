using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class MonobehaviourStopwatch : Stopwatch
    {
        private float timeLeft;

        private Coroutine timer;
        private UnityEvent timeLeftChanged;
        private UnityEvent timeOverEvent;

        private MonoBehaviour _monoBehaviour;

        public MonobehaviourStopwatch(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
            timeLeftChanged = new UnityEvent();
            timeOverEvent = new UnityEvent();
        }

        public void StartTimer()
        {
            timeLeft = Constants.TimeLimit;
            timer = _monoBehaviour.StartCoroutine(TimerProcess());
        }

        private IEnumerator TimerProcess()
        {
            while (timeLeft > 0)
            {
                yield return null;
                timeLeft -= Time.deltaTime;
                timeLeftChanged.Invoke();
            }

            timeUp();
        }

        private void timeUp()
        {
            StopTimer();
            timeOverEvent.Invoke();
        }

        public float getTime()
        {
            return timeLeft;
        }

        public void StopTimer()
        {
            _monoBehaviour.StopCoroutine(timer);
        }

        public void AddTimerChangedListener(UnityAction subscriber)
        {
            timeLeftChanged.AddListener(subscriber);
        }

        public void RemoveTimerChangedListener(UnityAction subscriber)
        {
            timeLeftChanged.RemoveListener(subscriber);
        }

        public void AddTimeUpListener(UnityAction subscriber)
        {
            timeOverEvent.AddListener(subscriber);
        }

        public void RemoveTimeUpListener(UnityAction subscriber)
        {
            timeOverEvent.RemoveListener(subscriber);
        }
    }
}
