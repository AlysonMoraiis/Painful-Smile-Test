using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

    private void IncreasesScore()
    {
        _gameData.Points += 1;
    }

    private void EndOfSession()
    {
        //show menu with play again and main menu buttons
    }
}
