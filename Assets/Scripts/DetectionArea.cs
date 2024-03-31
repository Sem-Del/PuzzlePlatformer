using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.TextCore.Text;

public enum AreaType
{
    MainArea,
    FirstPowerArea,
    WrongWay,
    Dialogue,
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

    void Start()
    {
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
            }else if (AreaType == AreaType.FirstPowerArea)
            {
                cam.backgroundColor = color2;
            }else if (AreaType == AreaType.WrongWay)
            {
                wrongWay1.Play();
            }else if (AreaType == AreaType.Dialogue && Trigger != null)
            {
                Trigger.startDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

    }

    AreaType GetAreaType(GameObject player)
    {
        return AreaType;
    }
}
