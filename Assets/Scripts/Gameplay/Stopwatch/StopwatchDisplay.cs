using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Image))]
    public class StopwatchDisplay : MonoBehaviour
    {
        private Image _clock;
        private TextMeshProUGUI _timeDisplay;
        private Stopwatch _timer;

        [SerializeField]
        private float _timerTime;

        private void OnValidate()
        {
            if (GetComponentInChildren<TextMeshProUGUI>() == null)
            {
                Destroy(this);
                throw new UnityException("TextMeshPro object not available");
            }

            if(GetComponent<Image>().sprite == null)
            {
                Destroy(this);
                throw new UnityException("No image set");
            }
        }

        public void InitialiseDisplay(Stopwatch timer)
        {
            _clock = GetComponent<Image>();
            _timeDisplay = GetComponentInChildren<TextMeshProUGUI>();
            _timer = timer;
            _timer.AddTimerChangedListener(timerInUse);
        }

        private void timerInUse()
        {
            _timerTime = _timer.getTime();
            updateTimeText();
            updateClockFilledAmound();
        }

        private void updateTimeText() 
        {
            _timeDisplay.text = TimeSpan.FromSeconds(_timer.getTime() + 1).Seconds.ToString();
        }

        private void updateClockFilledAmound() 
        {
            _clock.fillAmount = (float)_timer.getTime() / (float)Constants.TimeLimit;
        }
    }
}