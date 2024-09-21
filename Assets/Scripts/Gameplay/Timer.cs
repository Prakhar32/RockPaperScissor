using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class Timer
    {
        public float TimeLeft { get; private set; }

        private Coroutine timer;
        private UnityEvent timeLeftChanged;
        private UnityEvent timeOverEvent;

        private MonoBehaviour _monoBehaviour;

        public Timer(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
            timeLeftChanged = new UnityEvent();
            timeOverEvent = new UnityEvent();
        }

        public void StartTimer()
        {
            TimeLeft = Constants.TimeLimit;
            timer = _monoBehaviour.StartCoroutine(TimerProcess());
        }

        private IEnumerator TimerProcess()
        {
            while (TimeLeft > 0)
            {
                yield return null;
                TimeLeft -= Time.deltaTime;
                timeLeftChanged.Invoke();
            }

            timeUp();
        }

        private void timeUp()
        {
            StopTimer();
            timeOverEvent.Invoke();
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