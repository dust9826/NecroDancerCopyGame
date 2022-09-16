using UnityEngine;
using UnityEngine.Events;

public class InputKey : MonoBehaviour
{
    public UnityEvent onUpKeyDown;
    public UnityEvent onDownKeyDown;
    public UnityEvent onRightKeyDown;
    public UnityEvent onLeftKeyDown;

    private DirCode[] _keyCodes = new DirCode[2];

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            onUpKeyDown.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            onDownKeyDown.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            onRightKeyDown.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            onLeftKeyDown.Invoke();
        }
    }
}
