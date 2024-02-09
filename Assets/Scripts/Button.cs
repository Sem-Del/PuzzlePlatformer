using UnityEngine;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    LevelReset1,
    PlaceBlock,
    Pressed,
    Checkpoint,
    end,
}

public class Button : MonoBehaviour
{
    private bool isPressed = false;
    public Material Button_Not_Pressed;
    public Material Button_Pressed;
    public ButtonType buttonType;
    public GameObject MoveObject1;
    public GameObject MoveObject2;

    //public float moveObject1X = 30f;
    //public float moveObject1Y = 34f;

    void Start()
    {
        MoveObject1.transform.position = new Vector2(22.15f, 29.58f);
        MoveObject2.transform.position = new Vector2(23f, 33.4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MovePower") || collision.gameObject.CompareTag("endBlock"))
        {
            isPressed = true;
            ActivateButton();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("MovePower"))
        {
            isPressed = false;
            DeactivateButton();
        }
    }

    private void ActivateButton()
    {

        switch (buttonType)
        {
            case ButtonType.LevelReset1:
                GetComponent<Renderer>().material = Button_Pressed;
                MoveObject1.transform.position = new Vector2(22.15f, 29.58f);
                MoveObject2.transform.position = new Vector2(23f, 33.4f);
                Debug.Log("Level Reset");
                break;
            case ButtonType.PlaceBlock:
                Debug.Log("Block Placed");
                break;
            case ButtonType.Pressed:
                GetComponent<Renderer>().material = Button_Pressed;
                MoveObject2.transform.position = new Vector2(23f, 40f);
                break;
            case ButtonType.Checkpoint:

                break;
            case ButtonType.end:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                break;
        }
    }

    private void DeactivateButton()
    {
        GetComponent<Renderer>().material = Button_Not_Pressed;
    }

    public bool IsPressed()
    {
        return isPressed;
    }
}
