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

        void wrongway(int wrwa)
        {
            if (wrwa == 1)
            {
                wrongWay1.Play();
            }else if (wrwa == 2)
            {
                wrongWay2.Play();
            }
        }

    }

}
