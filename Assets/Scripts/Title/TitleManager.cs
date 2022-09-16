using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public GameObject pressUI = null;
    private bool isActive = false;
    [SerializeField]
    private float BlinkTime = 0.5f;

    private void Start()
    {
        StartCoroutine(BlinkPressUI());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneControl.Instance.QuitGame();
        }
        else if(Input.anyKeyDown)
        {
            SceneControl.Instance.LoadGameScene();
        }
    }

    IEnumerator BlinkPressUI()
    {
        WaitForSeconds second = new WaitForSeconds(BlinkTime);
        while(true)
        {
            isActive = !isActive;
            pressUI.SetActive(isActive);
            yield return second;
        }
    }
}
