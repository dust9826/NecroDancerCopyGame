using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : MonoBehaviour
{
    private float liveTime = 1f;
    private float moveSpeed = 524f;

    public int MoveDir
    {
        get;
        set;
    }

    private Vector3[] moveVec = new Vector3[2];

    private void Awake()
    {
        moveVec[0] = new Vector3(1, 0);
        moveVec[1] = new Vector3(-1, 0);
        MoveDir = 0;
    }

    void Update()
    {
        if(liveTime <= 0)
        {
            Destroy(this.gameObject);
        }
        transform.position += moveVec[MoveDir] * Time.deltaTime * moveSpeed;
        liveTime -= Time.deltaTime;
    }
}
