using UnityEngine.Events;

namespace Gameplay
{
    public interface Stopwatch
    {
        public void StartTimer();
        public void StopTimer();
        public float getTime();
        public void AddTimerChangedListener(UnityAction subscriber);
        public void RemoveTimerChangedListener(UnityAction subscriber);
        public void AddTimeUpListener(UnityAction subscriber);
        public void RemoveTimeUpListener(UnityAction subscriber);
    }
}