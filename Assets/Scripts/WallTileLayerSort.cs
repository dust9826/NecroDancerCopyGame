using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTileLayerSort : MonoBehaviour
{
    private float xpos;
    private float ypos;

    // Update is called once per frame
    void Update()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
        transform.position = new Vector3(xpos, ypos, ypos / 1000.0f);
    }
}