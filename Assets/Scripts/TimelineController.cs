using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector cutscene1;
    public PlayableDirector cutscene2;

    public bool move = false;
    public bool jump = false;

    private DetectionArea Detection;

    public void Update()
    {
        if (move == false && Input.GetKeyDown(KeyCode.A)) 
        {
            move = true;
            cutscene1.Play();
        }else if (move == false && Input.GetKeyDown(KeyCode.D))
        {
            move = true;
            cutscene1.Play();
        }

        if (jump == false && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            cutscene2.Play();
        }

    }

}
