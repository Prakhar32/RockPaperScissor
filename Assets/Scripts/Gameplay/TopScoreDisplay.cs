using TMPro;
using UnityEngine;

namespace StartMenu
{
    public class TopScoreDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _topScoreText;

        private void OnEnable()
        {
            _topScoreText.text = Constants.HighScoreText + PlayerPrefs.GetInt(Constants.PlayerPrefsHighScoreKey);
        }
    }
}