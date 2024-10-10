using TMPro;
using UnityEngine;
using System;

public class CurrentScoreDisplay : MonoBehaviour
{
    private CurrentScore _currentScore;
    private TextMeshProUGUI _displayText;

    public void Initialise(CurrentScore currentScore)
    {
        _currentScore = currentScore;
        _currentScore.AddListener(displayCurrentScore);
    }

    private void Start()
    {
        if (_currentScore == null)
        {
            Destroy(this);
            throw new MissingFieldException("Current Score reference not set");
        }

        if (GetComponent<TextMeshProUGUI>() == null)
        {
            Destroy(this);
            throw new MissingComponentException("Missing TextMeshPro component");
        }
        else
        {
            _displayText = GetComponent<TextMeshProUGUI>();
            _displayText.text = "Score : " + _currentScore.GetScore();
        }
    }

    private void displayCurrentScore()
    {
        _displayText.text = "Score : " + _currentScore.GetScore();
    }
}
