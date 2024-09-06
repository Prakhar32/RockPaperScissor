using Gameplay;
using UnityEngine;

namespace StartMenu
{
    public class StartMenuDisplay : MonoBehaviour
    {
        [SerializeField]
        GameplayDisplay _gameplayDisplay;

        public void StartButtonClicked()
        {
            _gameplayDisplay.StartGame();
        }

        public void ExitButtonClicked()
        {
            Application.Quit();
        }
    }
}