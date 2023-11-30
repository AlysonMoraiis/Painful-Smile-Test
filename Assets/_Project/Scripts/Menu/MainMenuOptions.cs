using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField] private Button _backButton;

    [SerializeField] private MainMenuManager _mainMenuManager;

    [SerializeField] private GameData _gameData;
    
    [Header("Game Session Time")]
    [SerializeField] private TMP_Text _gameSessionTimeText;
    [SerializeField] private float _sessionMinSliderAmount = 60;
    [SerializeField] private float _sessionMaxSliderAmount = 180;
    [SerializeField] private Slider _gameSessionTimeSlider;
    
    [Header("Enemy Spawn Time")]
    [SerializeField] private TMP_Text _enemySpawnTimeText;
    [SerializeField] private float _spawnMinSliderAmount = 5;
    [SerializeField] private float _spawnMaxSliderAmount = 20;
    [SerializeField] private Slider _enemySpawnTimeSlider;
    

    private void Awake()
    {
        InitializeSessionAndSpawnTimeValues();
    }

    private void OnEnable()
    {
        _backButton.onClick.AddListener(HandleBackButton);
        _gameSessionTimeSlider.onValueChanged.AddListener(UpdateGameSessionValue);
        _enemySpawnTimeSlider.onValueChanged.AddListener(UpdateEnemySpawnValue);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(HandleBackButton);
        _gameSessionTimeSlider.onValueChanged.RemoveListener(UpdateGameSessionValue);
        _enemySpawnTimeSlider.onValueChanged.RemoveListener(UpdateEnemySpawnValue);
    }

    private void HandleBackButton()
    {
        _mainMenuManager.HandleOptionsButton();
    }

    private void InitializeSessionAndSpawnTimeValues()
    {
        _gameSessionTimeSlider.minValue = _sessionMinSliderAmount;
        _gameSessionTimeSlider.maxValue = _sessionMaxSliderAmount;
        _gameSessionTimeSlider.value = _gameData.SessionTime;
        
        _enemySpawnTimeSlider.minValue = _spawnMinSliderAmount;
        _enemySpawnTimeSlider.maxValue = _spawnMaxSliderAmount;
        _enemySpawnTimeSlider.value = _gameData.EnemySpawnTime;
        
        SetEnemySpawnTimerText();
        SetGameSessionTimerText();
    }

    private void UpdateGameSessionValue(float value)
    {
        _gameData.SessionTime = value;
        SetGameSessionTimerText();
    }
    
    private void UpdateEnemySpawnValue(float value)
    {
        _gameData.EnemySpawnTime = value;
        SetEnemySpawnTimerText();
    }

    private void SetGameSessionTimerText()
    {
        float sessionTime = _gameData.SessionTime;
        int minutes = Mathf.FloorToInt((sessionTime / 60));
        int seconds = Mathf.FloorToInt(sessionTime % 60);
        _gameSessionTimeText.text = $"{minutes:00}:{seconds:00}";
    }
    
    private void SetEnemySpawnTimerText()
    {
        float spawnTime = _gameData.EnemySpawnTime;
        int minutes = Mathf.FloorToInt((spawnTime / 60));
        int seconds = Mathf.FloorToInt(spawnTime % 60);
        _enemySpawnTimeText.text = $"{minutes:00}:{seconds:00}";
    }
}
