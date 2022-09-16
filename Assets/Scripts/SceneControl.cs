using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private SceneControl() { }

    private static SceneControl instance;

    public static SceneControl Instance
    {
        get
        {
            if (instance == null)
                instance = new SceneControl();
            return instance;
        }
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
