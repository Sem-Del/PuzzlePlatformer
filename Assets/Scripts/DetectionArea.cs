using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum AreaType
{
    MainArea,
    FirstPowerArea,
    WrongWay,
}


public class DetectionArea : MonoBehaviour
{
    private TimelineController Animation;

    private Color mainBlue = new Color(0.1921569f, 0.3019608f, 0.4745098f, 0f);
    private Color color2 = new Color(0.8962264f, 0.2676961f, 0.1479619f, 0f);

    public Camera cam;
    public AreaType AreaType;

    private TimelineController timeline;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AreaType AreaType = GetAreaType(other.gameObject);

            if (AreaType == AreaType.MainArea)
            {
                Debug.Log("Main area");
                cam.backgroundColor = mainBlue;
            }else if (AreaType == AreaType.FirstPowerArea)
            {
                Debug.Log("New area");
                cam.backgroundColor = color2;
            }else if (AreaType == AreaType.WrongWay)
            {
                timeline.wrongway(1);
                Debug.Log("Wrong Way");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (AreaType == AreaType.WrongWay)
            {

                if (AreaType == AreaType.WrongWay)
                {
                    Debug.Log("Wrong Way");
                    timeline.wrongway(2);
                }
                
            }
        }
    }

    AreaType GetAreaType(GameObject player)
    {
        return AreaType;
    }
}
