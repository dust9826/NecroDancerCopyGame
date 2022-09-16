using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCanvas;
    [SerializeField] GameObject _gameClearCanvas;
    
    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
    }

    public void GameClear()
    {
        _gameClearCanvas.SetActive(true);
    }
}
