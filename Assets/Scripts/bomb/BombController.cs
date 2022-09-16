using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField]
    Sprite[] _bomb_sprites = null;

    [SerializeField]
    SpriteRenderer _renderer = null;

    [SerializeField]
    GameObject _explosion = null;

    private int _explodeCount = 0;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _bomb_sprites[_explodeCount];
    }

    public bool ExplodeCount()  //터지면 true
    {
        _explodeCount++;
        if(_explodeCount == _bomb_sprites.Length)
        {
            GameObject explosion = Explosion();
            Destroy(this.gameObject);
            Destroy(explosion, 0.5f);
            DamageAll();
            return true;
        }
        _renderer.sprite = _bomb_sprites[_explodeCount];
        return false;
    }

    void DamageAll()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(2, 2), 0);
        foreach(Collider2D collider in colliders)
        {
            collider.GetComponent<ObjectInfo>().HP -= 1;
        }
    }

    GameObject Explosion()
    {
        GameObject newExplosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        return newExplosion;
    }
}
