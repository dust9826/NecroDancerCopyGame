using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField]
    GameObject _bombPrefab = null;

    List<BombController> _controllers;

    private void Start()
    {
        _controllers = new List<BombController>();
    }

    public void CreateBomb(Vector2 pos)
    {
        GameObject newBomb = Instantiate(_bombPrefab, pos, Quaternion.identity);
        PushBombController(newBomb.GetComponent<BombController>());
    }

    void PushBombController(BombController controller)
    {
        _controllers.Add(controller);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Wall"))
        {
            /*니코드 있자너*/
        }
    }

    public void ActiveAllBomb()
    {
        for(int i = 0; i < _controllers.Count; i++)
        {
            if(_controllers[i].ExplodeCount())
            {
                _controllers.Remove(_controllers[i]);
            }
        }
    }
}
