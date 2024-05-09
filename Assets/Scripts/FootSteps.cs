using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public GameObject footstep;
    public GameObject running;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
        running.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("s"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("a"))
        {
            footsteps();
        }

        if(Input.GetKeyDown("d"))
        {
            footsteps();
        }

        if(Input.GetKeyUp("w"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("s"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("a"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyUp("d"))
        {
            StopFootsteps();
        }

        if(Input.GetKeyDown("left shift"))
        {
            Running();
        }

        if(Input.GetKeyUp("left shift"))
        {
            StopRunning();
        }

    
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }

    void Running()
    {
        running.SetActive(true);
    }

    void StopRunning()
    {
        running.SetActive(false);
    }
}