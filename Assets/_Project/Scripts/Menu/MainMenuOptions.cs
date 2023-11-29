using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] private Button _backButton;

    [SerializeField] private MainMenuManager _mainMenuManager;

    [SerializeField] private GameData _gameData;
    [SerializeField] private TMP_Text _gameSessionTimeText;
    [SerializeField] private TMP_Text _enemySpawnTimeText;

    private void OnEnable()
    {
        UpdateSessionAndSpawnTime();
        _backButton.onClick.AddListener(HandleBackButton);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(HandleBackButton);
    }

    private void HandleBackButton()
    {
        _mainMenuManager.HandleOptionsButton();
    }

    private void UpdateSessionAndSpawnTime()
    {
        _gameSessionTimeText.text = "Game Session Time: " + _gameData.SessionTime.ToString();
        _enemySpawnTimeText.text = "Enemy Spawn Time: " + _gameData.EnemySpawnTime.ToString();
    }
}
