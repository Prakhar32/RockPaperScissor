using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class CurrentScoreKeeper : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        private int currentScore;

        public void increaseScore()
        {
            currentScore++;
            _scoreText.text = Constants.ScoreText + currentScore;
        }

        public void checkIfTopScore()
        {
            if (PlayerPrefs.GetInt(Constants.PlayerPrefsScoreText) < currentScore)
                PlayerPrefs.SetInt(Constants.PlayerPrefsScoreText, currentScore);
        }

        public void resetScore()
        {
            currentScore = 0;
            _scoreText.text = Constants.ScoreText + currentScore;
        }
    }
}