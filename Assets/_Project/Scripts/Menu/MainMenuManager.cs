using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionsButton;

    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _optionsMenuScreen;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(HandlePlayButton);
        _optionsButton.onClick.AddListener(HandleOptionsButton);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(HandlePlayButton);
        _optionsButton.onClick.RemoveListener(HandleOptionsButton);
    }

    private void HandlePlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HandleOptionsButton()
    {
        _mainMenuScreen.SetActive(!_mainMenuScreen.activeSelf);
        _optionsMenuScreen.SetActive(!_optionsMenuScreen.activeSelf);
    }
}
