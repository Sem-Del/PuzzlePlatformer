using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector cutsceneOne;
    public PlayableDirector cutsceneTwo;
    public PlayableDirector wrongWay1;
    public PlayableDirector wrongWay2;

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
        else if (jump == false && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            cutsceneTwo.Play();
        }

    }

    public void wrongway(int wrongWay)
    {
        if (wrongWay == 1)
        {
            wrongWay1.Play();
        }
        else if (wrongWay == 2)
        {
            wrongWay2.Play();
        }
    }

}
