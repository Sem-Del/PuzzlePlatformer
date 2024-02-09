using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    // Ways to go to a other scene with code ( every scene has to be added in the buildindex (file - buildSettings) )

    // Load a scene that is a specific amout of scenes from the current scene. Use + and - and the scenes your'e away from the scene in the current scene to go that scene.
    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex (+ or -) (How many Scenes you have to go up or down) );
    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    // This works only if the scene is below the current scene in the buildindex.
    // SceneManager.LoadScene("(SceneName)");
    // SceneManager.LoadScene("TestScene");

    // It is possible that the cursor is stuck or not visible because of the scene you were in before you can fix it with these lines of code.

    // Show the cursor.
    // Cursor.visible = true;

    // Let the cursor move.
    // Cursor.lockState = CursorLockMode.None;

    // You can also quit the application for a exit button or something with the following code.
    // Application.Quit();

    void Start()
    {
        // Show and let the cursor move
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void start()
    {
        // Load the scene named game (needs to be lower then the current scene in the buildindex)
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        // Quit the game / application
        Application.Quit();
    }
}
