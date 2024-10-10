using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class CurrentScore
{
    private int _score;
    private UnityEvent _scoreChangedEvent = new UnityEvent();

    public int GetScore()
    {
        return _score;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreChangedEvent.Invoke();
    }

    public void IncreaseScore(int increment)
    {
        _score += increment;
        _scoreChangedEvent.Invoke();
    }

    public void Reset()
    {
        _score = 0;
    }

    public void AddListener(UnityAction listener)
    {
        _scoreChangedEvent.AddListener(listener);
    }
}
