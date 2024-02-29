using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector cutsceneOne;
    public PlayableDirector cutsceneTwo;

    public bool move = false;
    public bool jump = false;

    private DetectionArea Detection;

    public void Update()
    {
        if (move == false && Input.GetKeyDown(KeyCode.A)) 
        {
            move = true;
            cutsceneOne.Play();
        }else if (move == false && Input.GetKeyDown(KeyCode.D))
        {
            move = true;
            cutsceneOne.Play();
        }

        if (jump == false && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            cutsceneTwo.Play();
        }

    }

}
