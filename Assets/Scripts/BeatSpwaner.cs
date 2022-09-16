using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpwaner : MonoBehaviour
{
    public GameObject _beatPrefab;

    public RectTransform[] spawnPoint = null;

    public void SpwanBeat()
    {
        if(spawnPoint.Length != 2)
            return;

        for(int i=0;i<2;i++)
        {
            GameObject newBeat = Instantiate(_beatPrefab, spawnPoint[i].position, 
                Quaternion.identity, this.transform.parent);
            newBeat.GetComponent<BeatController>().MoveDir = i;
        }
    }
}
