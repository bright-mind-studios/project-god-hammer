using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStateController : BaseStateController
{
    public VillageStats villageStats;

    [HideInInspector] public WorldStateController worldController; //maybe should hide it and find it on Awake
    [HideInInspector] public AudioSource audioSource;

    public override void InitializeStateMachine(bool activate)
    {
        base.InitializeStateMachine(activate);
        worldController = FindObjectOfType<WorldStateController>();
        //Add the initial position for the village. Maybe making a call to the worldmanager to find a valid position. Also maybe, calling the parsing world
        // Call to show the Alex bar with the villageStats
    }
}