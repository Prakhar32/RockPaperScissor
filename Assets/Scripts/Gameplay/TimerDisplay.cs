using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Gameplay
{
    [RequireComponent(typeof(Image))]
    public class TimerDisplay : MonoBehaviour
    {
        private Image _clock;
        private TextMeshProUGUI _timeDisplay;
        private Timer _timer;

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

        public void InitialiseDisplay(Timer timer)
        {
            _clock = GetComponent<Image>();
            _timeDisplay = GetComponentInChildren<TextMeshProUGUI>();
            _timer = timer;
            _timer.AddTimerChangedListener(timerInUse);
        }

        private void timerInUse()
        {
            _timerTime = _timer.TimeLeft;
            updateTimeText();
            updateClockFilledAmound();
        }

        private void updateTimeText() 
        {
            _timeDisplay.text = TimeSpan.FromSeconds(_timer.TimeLeft).ToString(@"m\:ss");
        }

        private void updateClockFilledAmound() 
        {
            _clock.fillAmount = (float)_timer.TimeLeft / (float)Constants.TimeLimit;
        }
    }
}