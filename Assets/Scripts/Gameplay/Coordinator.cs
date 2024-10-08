using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class Coordinator : MonoBehaviour
    {
        [SerializeField]
        private DecisionMaker _decisionMaker;

        [SerializeField]
        private StopwatchDisplay _timerDisplay;

        private Stopwatch _timer;

        [SerializeField]
        private GameObject _gameScreen;

        [SerializeField]
        private GameObject _mainMenuScreen;

        [SerializeField]
        private CurrentScoreKeeper _currentScoreKeeper;

        private bool _acceptInput;

        delegate void RemainingSequence();

        public void Initialise()
        {
            _timer = new MonobehaviourStopwatch(this);
            _timerDisplay.InitialiseDisplay(_timer);
            _timer.AddTimeUpListener(GameOver);
        }

        public void StartGame()
        {
            _currentScoreKeeper.resetScore();
            StartNewRound();
        }

        private void StartNewRound()
        {
            _timer.StartTimer();
            _acceptInput = true;
            _decisionMaker.ResetState();
        }

        public void WonRound()
        {
            _currentScoreKeeper.increaseScore();
            PauseForABit(() => StartNewRound());
        }

        public void DrewRound()
        {
            PauseForABit(() => StartNewRound());
        }

        public void GameOver()
        {
            _currentScoreKeeper.checkIfTopScore();
            PauseForABit(() => returnToMainScreen());
        }

        private void returnToMainScreen()
        {
            _gameScreen.SetActive(false);
            _mainMenuScreen.SetActive(true);
        }

        private void PauseForABit(RemainingSequence sequence)
        {
            _timer.StopTimer();
            _acceptInput = false;
            StartCoroutine(waitForSomeTime(sequence));
        }
        private IEnumerator waitForSomeTime(RemainingSequence sequence)
        {
            yield return new WaitForSeconds(Constants.WaitTime);
            sequence.Invoke();
        }

        public void TakeUserMove(Choice userMove)
        {
            if (!_acceptInput) return;
            _decisionMaker.MakeDecision(userMove);
            _acceptInput = false;
        }

    }
}