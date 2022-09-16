using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Vector3[] direction = new Vector3[4];

    [SerializeField]
    protected GameObject _characterImage = null;

    protected SpriteRenderer _renderer;

    protected virtual void Start()
    {
        direction[(int)DirCode.UP] = new Vector3(0, 1, 0);
        direction[(int)DirCode.DOWN] = new Vector3(0, -1, 0);
        direction[(int)DirCode.RIGHT] = new Vector3(1, 0, 0);
        direction[(int)DirCode.LEFT] = new Vector3(-1, 0, 0);

        _renderer = _characterImage.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        
    }

    public virtual void Action(DirCode[] code)
    {
        if(code[0] == DirCode.NULL)     //아무것도 안함
        {

        }
        else if(code[1] == DirCode.NULL)    //이동
        {
            ObjectCode objectCode = MoveCheck(code[0]);
            if (objectCode == ObjectCode.NULL)
            {
                Move(code[0]);
            }
            else
            {

            }
        }
        else     //스킬 사용
        {

        }
    }

    protected ObjectCode MoveCheck(DirCode code)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position + direction[(int)code], 0.1f);
        if (colliders.Length != 0)
        {
            return colliders[0].GetComponent<ObjectInfo>().Object_Info;
        }
        return ObjectCode.NULL;
    }

    protected void DamageObject(DirCode code, int damage)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position + direction[(int)code], 0.1f);
        if (colliders.Length != 0)
        {
            colliders[0].GetComponent<ObjectInfo>().HP -= damage;
        }
    }

    public virtual void Move(DirCode code)
    {
        Jump();
        SoftMove(direction[(int)code]);
        Debug.Log(code);
    }

    public virtual void DamageSelf(int hp)
    {
        Destroy(gameObject);
    }

    protected IEnumerator Jump()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        Vector3 moveVec = new Vector3(0, 0.3f, 0);
        for (int i=0;i<7;i++)
        {
            _characterImage.transform.position += moveVec;
            moveVec -= new Vector3(0, 0.1f, 0);
            yield return wait;
        }
    }

    protected IEnumerator SoftMove(Vector3 moveVec)
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        for (int i = 0; i < 7; i++)
        {
            transform.position += moveVec / 7;
            yield return wait;
        }
    }
}
