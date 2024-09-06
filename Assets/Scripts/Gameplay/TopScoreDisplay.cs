using TMPro;
using UnityEngine;

namespace StartMenu
{
    public class TopScoreDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _topScoreText;

        // Start is called before the first frame update
        private void OnEnable()
        {
            _topScoreText.text = Constants.TopScoreText + PlayerPrefs.GetInt(Constants.PlayerPrefsScoreText);
        }
    }
}