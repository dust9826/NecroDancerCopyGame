using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    List<Enemy> _enemies = new List<Enemy>();

    public UnityEvent gameClear;

    public void ActiveAllEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].Action(_enemies[i].MonsterPattern());
        }
        if(_enemies.Count == 0)
        {
            gameClear.Invoke();
        }
    }

    public void DeleteEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);

    }
}
