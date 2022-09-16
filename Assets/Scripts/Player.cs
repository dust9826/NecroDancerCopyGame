using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : Character
{
    private DirCode[] _keyCodes = new DirCode[2];
    public UnityEvent gameOver;

    [SerializeField]
    BombManager _bombManager = null;

    [SerializeField]
    Image[] _hearts = null;

    [SerializeField]
    Sprite _noHeart = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ResetKey();
    }

    public override void Move(DirCode code)
    {
        if (direction[(int)code] == direction[(int)DirCode.RIGHT])
        {
            if (_renderer.flipX)
            {
                _renderer.flipX = false;
            }
        }
        else if (direction[(int)code] == direction[(int)DirCode.LEFT])
        {
            if (!_renderer.flipX)
            {
                _renderer.flipX = true;
            }
        }
        StartCoroutine(SoftMove(direction[(int)code]));
        StartCoroutine(Jump());
    }

    public void AddKey(DirCode code)
    {
        if (_keyCodes[0] == DirCode.NULL)
        {
            _keyCodes[0] = code;
        }
        else if (_keyCodes[1] == DirCode.NULL && code != _keyCodes[0])
        {
            _keyCodes[1] = code;
        }
    }

    public void ResetKey()
    {
        for (int i = 0; i < _keyCodes.Length; i++)
        {
            _keyCodes[i] = DirCode.NULL;
        }
    }

    public DirCode[] GetKey()
    {
        return _keyCodes;
    }

    public override void Action(DirCode[] code)
    {
        if (code[0] == DirCode.NULL)     //아무것도 안함
        {

        }
        else if (code[1] == DirCode.NULL)    //이동
        {
            ObjectCode objectCode = MoveCheck(code[0]);
            if (objectCode == ObjectCode.NULL)
            {
                Move(code[0]);
            }
            else if(objectCode == ObjectCode.WALL)
            {
                DamageObject(code[0], 1);
            }
            else if (objectCode == ObjectCode.ENEMY)
            {
                DamageObject(code[0], 1);
            }
        }
        else     //스킬 사용
        {
            if ((code[0] == DirCode.UP && code[1] == DirCode.LEFT)
                || (code[0] == DirCode.LEFT && code[1] == DirCode.UP))
            {
                _bombManager.CreateBomb(this.transform.position);
            }
        }
    }

    public override void DamageSelf(int hp)
    {
        if(hp < 3)
        {
            _hearts[0].sprite = _noHeart;
        }
        if (hp < 2)
        {
            _hearts[1].sprite = _noHeart;
        }
        if (hp < 1)
        {
            _hearts[2].sprite = _noHeart;
            Camera.main.transform.parent = transform.parent;
            gameOver.Invoke();
        }
    }

    //public Collider2D[] GetEnemyChunk()
    //{
    //    //Collider2D[] enemies = Physics2D.OverlapBoxAll(transform.position, new Vector2(11,8),0f, LayerMask)
    //    //return enemies;
    //}
}
