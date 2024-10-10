using TMPro;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CurrentScoreKeeper : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;
        private int _currentScore;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        public void increaseScore()
        {
            _currentScore++;
            _scoreText.text = Constants.ScoreText + _currentScore;
        }

        public void checkIfTopScore()
        {
            if (PlayerPrefs.GetInt(Constants.PlayerPrefsHighScoreKey) < _currentScore)
                PlayerPrefs.SetInt(Constants.PlayerPrefsHighScoreKey, _currentScore);
        }

        public int getCurrentScore()
        {
            return _currentScore;
        }

        public void resetScore()
        {
            _currentScore = 0;
            _scoreText.text = Constants.ScoreText + _currentScore;
        }
    }
}