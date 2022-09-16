using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Presenter : MonoBehaviour
{
    [SerializeField] InputKey _inputKey;
    [SerializeField] Player _player;
    [SerializeField] TimingControl _timingControl;
    [SerializeField] Animator _animator;
    [SerializeField] BeatSpwaner _beatSpwaner;
    [SerializeField] BombManager _bombManager;
    [SerializeField] EnemyController _enemyController;
    [SerializeField] GameEndController _gameEndController;

    private Vector2 dir;

    private void Start()
    {
        _inputKey.onUpKeyDown.AddListener(OnInputUpKeyDown);
        _inputKey.onDownKeyDown.AddListener(OnInputDownKeyDown);
        _inputKey.onRightKeyDown.AddListener(OnInputRightKeyDown);
        _inputKey.onLeftKeyDown.AddListener(OnInputLeftKeyDown);

        _timingControl.moveAll.AddListener(MoveAll);

        _player.gameOver.AddListener(OnGameOver);
        _enemyController.gameClear.AddListener(OnGameClear);
    }

    void OnInputUpKeyDown()
    {
        if(_timingControl.IsTiming())
            _player.AddKey(DirCode.UP);
    }

    void OnInputDownKeyDown()
    {
        if (_timingControl.IsTiming())
            _player.AddKey(DirCode.DOWN);
    }

    void OnInputRightKeyDown()
    {
        if (_timingControl.IsTiming())
            _player.AddKey(DirCode.RIGHT);
    }

    void OnInputLeftKeyDown()
    {
        if (_timingControl.IsTiming())
            _player.AddKey(DirCode.LEFT);
    }

    void MoveAll()
    {
        //플레이어 움직임
        _player.Action(_player.GetKey());
        _player.ResetKey();

        //심장박동
        _animator.SetTrigger("Beating");
        _beatSpwaner.SpwanBeat();

        //폭탄작동
        _bombManager.ActiveAllBomb();

        //적 움직임
        _enemyController.ActiveAllEnemies();
    }

    void OnGameOver()
    {
        _gameEndController.GameOver();
    }

    void OnGameClear()
    {
        _gameEndController.GameClear();
    }
}
