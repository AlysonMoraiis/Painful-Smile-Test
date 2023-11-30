using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _totalPointsText;
    [SerializeField] private GameData _gameData;

    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _mainMenuButton;

    private void OnEnable()
    {
        SetTotalPointsText();
        _playAgainButton.onClick.AddListener(HandlePlayAgainButton);
        _mainMenuButton.onClick.AddListener(HandleMainMenuButton);
    }

    private void OnDisable()
    {
        _playAgainButton.onClick.RemoveListener(HandlePlayAgainButton);
        _mainMenuButton.onClick.RemoveListener(HandleMainMenuButton);
    }

    private void SetTotalPointsText()
    {
        _totalPointsText.text = _gameData.Points.ToString();
    }

    private void HandlePlayAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HandleMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
