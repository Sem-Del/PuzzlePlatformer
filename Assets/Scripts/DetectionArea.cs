using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public enum AreaType
{
    MainArea,
    FirstPowerArea,
    WrongWay,
    Dialogue,
    ArenaEntrance,
    ArenaLeave,
}

public class DetectionArea : MonoBehaviour
{
    private TimelineController Animation;

    private Color mainBlue = new Color(0.1921569f, 0.3019608f, 0.4745098f, 0f);
    private Color color2 = new Color(0.8962264f, 0.2676961f, 0.1479619f, 0f);

    public Camera cam;
    public AreaType AreaType;

    private TimelineController timeline;
    public Dialog Trigger;

    public PlayableDirector wrongWay1;

    public GameObject arenaWall1;
    public GameObject arenaWall2;
    public GameObject arenaWall3;

    public Camera mainCamera;
    public Camera arenaCamera;

    void Start()
    {
        arenaWall1.SetActive(false);
        arenaWall2.SetActive(false);
        arenaWall3.SetActive(false);
        mainCamera.enabled = true;
        arenaCamera.enabled = false;

        Trigger = FindObjectOfType<Dialog>();
        if (Trigger == null)
        {
            Debug.LogError("Error: Dialog component not found!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AreaType AreaType = GetAreaType(other.gameObject);

            if (AreaType == AreaType.MainArea)
            {
                cam.backgroundColor = mainBlue;
            }
            else if (AreaType == AreaType.FirstPowerArea)
            {
                cam.backgroundColor = color2;
            }
            else if (AreaType == AreaType.WrongWay)
            {
                wrongWay1.Play();
            }
            else if (AreaType == AreaType.Dialogue && Trigger != null)
            {
                Trigger.startDialogue();
            }
            else if (AreaType == AreaType.ArenaEntrance)
            {
                arenaWall1.SetActive(true);
                arenaWall2.SetActive(true);
                arenaWall3.SetActive(true);
                arenaCamera.enabled = true;
                mainCamera.enabled = false;
            }
            else if (AreaType == AreaType.ArenaLeave)
            {
                mainCamera.enabled = true;
                arenaCamera.enabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AreaType AreaType = GetAreaType(other.gameObject);
        }
    }

    AreaType GetAreaType(GameObject player)
    {
        return AreaType;
    }
}
