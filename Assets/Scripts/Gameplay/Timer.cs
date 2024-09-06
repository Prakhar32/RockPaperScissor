using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private Image _clock;

        [SerializeField]
        TextMeshProUGUI _timeDisplay;

        private float _timeLeft;
        private bool _timerStarted;

        [SerializeField]
        private Coordinator _game;

        public void StartTimer()
        {
            _timeLeft = Constants.TimeLimit;
            _timerStarted = true;
        }

        private void Update()
        {
            if (_timerStarted)
            {
                if (_timeLeft > 0)
                {
                    _timeDisplay.text = TimeSpan.FromSeconds(_timeLeft).ToString(@"mm\:ss");
                    _clock.fillAmount = (float)_timeLeft / (float)Constants.TimeLimit;
                    _timeLeft -= Time.deltaTime;
                }
                else
                    TimeOver();
            }
        }

        public void StopTimer() 
        {
            _timerStarted = false;
        }

        private void TimeOver()
        {
            _timerStarted = false;
            _game.GameOver();
        }
    }
}