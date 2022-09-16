using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    EnemyController controller = null;

    [SerializeField]
    EnemyCode _enemyCode = EnemyCode.NULL;

    [SerializeField]
    bool isJump = true;

    private bool isUp = false;

    protected override void Start()
    {
        base.Start();
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
            else if (objectCode == ObjectCode.PLAYER)
            {
                DamageObject(code[0], 1);
            }

        }
        else
        {

        }
    }

    public override void Move(DirCode code)
    {
        StartCoroutine(SoftMove(direction[(int)code]));
        if(isJump)
        {
            StartCoroutine(Jump());
        }
    }

    public DirCode[] MonsterPattern()
    {
        if(_enemyCode == EnemyCode.Slime)
        {
            isUp = !isUp;
            if (isUp)
            {
                return new DirCode[2] { DirCode.DOWN, DirCode.NULL };
            }
            else
            {
                return new DirCode[2] { DirCode.UP, DirCode.NULL };
            }
        }
        else if(_enemyCode == EnemyCode.Bat)
        {
            isUp = !isUp;
            if (isUp)
            {
                return new DirCode[2] { DirCode.RIGHT, DirCode.NULL };
            }
            else
            {
                return new DirCode[2] { DirCode.LEFT, DirCode.NULL };
            }
        }
        return new DirCode[] { DirCode.NULL, DirCode.NULL };
    }

    public override void DamageSelf(int hp)
    {
        if(hp <= 0)
        {
            controller.DeleteEnemy(GetComponent<Enemy>());
            Destroy(gameObject);
        }
    }
}
