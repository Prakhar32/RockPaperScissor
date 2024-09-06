using UnityEngine;

namespace StartMenu
{
    public class FaceOffChartDisplay : MonoBehaviour
    {
        [SerializeField]
        private GameObject chartPanel;

        public void ShowChartButtonClicked()
        {
            chartPanel.SetActive(true);
        }

        public void MainMenuButtonClicked()
        {
            chartPanel.SetActive(false);
        }
    }
}