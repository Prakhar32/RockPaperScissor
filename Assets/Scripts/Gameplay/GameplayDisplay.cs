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
            _mainScreen.SetActive(false);
            _gameplayScreen.SetActive(true);
        }

        public void EndGame()
        {
            _gameplayScreen.SetActive(false);
            _mainScreen.SetActive(true);
        }
    }
}