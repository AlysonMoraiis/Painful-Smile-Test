using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameSessionManager _gameSessionManager;
    [SerializeField] private GameObject _gameOverScreen;

    private void Awake()
    {
        SetTimeScale(1);
    }

    private void OnEnable()
    {
        _gameSessionManager.OnTimeOut += EndOfSession;
    }

    private void OnDisable()
    {
        _gameSessionManager.OnTimeOut -= EndOfSession;
    }

    private void IncreasesScore()
    {
        _gameData.Points += 1;
    }

    private void EndOfSession()
    {
        SetTimeScale(0);
        OpenGameOverScreen();
    }

    private void OpenGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }

    private void SetTimeScale(int value)
    {
        Time.timeScale = value;
    }
}
