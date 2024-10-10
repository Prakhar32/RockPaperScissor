using Storage;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshPro;

    void Start()
    {
        if (GetComponent<TextMeshProUGUI>() == null)
        {
            Destroy(this);
            throw new MissingComponentException("TextMeshProUGUI component missing");
        }
        else
            m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void LoadHighScore()
    {
        //m_TextMeshPro.text = Constants.HighScoreText + Reader.ReadData(Constants.PlayerPrefsHighScoreKey);
    }
}
