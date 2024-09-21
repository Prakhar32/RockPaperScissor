using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class GameplayDisplay : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameplayScreen;

        [SerializeField]
        private GameObject _mainScreen;

        [SerializeField]
        private GameplayInitializer _gameplayInitializer;

        public void StartGame()
        {
            _gameplayInitializer.Initialise();
            switchToGameScreen();
            _gameplayInitializer.StartGame();
        }

        private void switchToGameScreen()
        {
            switchScreen(true);
        }

        private void switchToMainMenuScreen()
        {
            switchScreen(false);
        }

        private void switchScreen(bool state)
        {
            _mainScreen.SetActive(!state);
            _gameplayScreen.SetActive(state);
        }
    }
}