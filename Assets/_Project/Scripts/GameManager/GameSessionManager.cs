using System;
using UnityEngine;
using TMPro;

public class GameSessionManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameData _gameData;

    private float _remainingTime = 5;

    private int _minutes;
    private int _seconds;

    public event Action OnTimeOut;

    private void Awake()
    {
        _remainingTime = _gameData.SessionTime;
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
        }
        else
        {
            _remainingTime = 0;
            OnTimeOut?.Invoke();
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        _minutes = Mathf.FloorToInt((_remainingTime / 60));
        _seconds = Mathf.FloorToInt(_remainingTime % 60);
        _timerText.text = $"{_minutes:00}:{_seconds:00}";
    }
}
