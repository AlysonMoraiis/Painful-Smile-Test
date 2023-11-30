using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameSessionManager _gameSessionManager;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        SetTimeScale(1);
        ResetPoints();
    }

    private void OnEnable()
    {
        _gameSessionManager.OnTimeOut += EndOfSession;
        _playerHealth.OnDestroyShip += EndOfSession;
    }

    private void OnDisable()
    {
        _gameSessionManager.OnTimeOut -= EndOfSession;
        _playerHealth.OnDestroyShip -= EndOfSession;
    }

    private void ResetPoints()
    {
        if (_gameData.Points > _gameData.Highscore)
        {
            UpdateHighscore();
        }
        _gameData.Points = 0;
    }

    private void UpdateHighscore()
    {
        _gameData.Highscore = _gameData.Points;
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
