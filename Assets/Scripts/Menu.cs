using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    // Ways to go to a other scene ( every scene has to be in the buildSettings (file - buildSettings)

    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex (+ or -) (How many Scenes you have to go up or down) );

    // works only if the scene is below the current scene in the buildindex 
    // SceneManager.LoadScene("(SceneName)");

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void start()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void quit()
    {
        Application.Quit();
    }
}
