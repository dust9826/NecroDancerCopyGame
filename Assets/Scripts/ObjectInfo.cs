using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    [SerializeField]
    private ObjectCode _objectInfo;

    public ObjectCode Object_Info
    {
        get { return _objectInfo; }
    }

    [SerializeField]
    private int _hp = 1;

    public int HP
    {
        get { return _hp; }
        set
        {
            _hp = value;
            if (_objectInfo == ObjectCode.ENEMY || _objectInfo == ObjectCode.PLAYER)
            {
                GetComponent<Character>().DamageSelf(_hp);
            }
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
