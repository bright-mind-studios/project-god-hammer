using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageStateController : BaseStateController
{
    public VillageData villageData;

    [HideInInspector] public WorldStateController worldController; //maybe should hide it and find it on Awake
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public ArmourBar armourBar;
    [HideInInspector] public Quest currentQuest;

    public List<AudioClip> audioClips;


    public override void InitializeStateMachine(bool activate)
    {
        base.InitializeStateMachine(activate);
        worldController = FindObjectOfType<WorldStateController>();
        armourBar = GetComponentInChildren<ArmourBar>();
        villageData = new VillageData
        {
            lives = worldController.worldData.intensity.villagesLives
        };
        armourBar.SetMaxSecondsOfArmour(worldController.worldData.difficulty.GetMaxArmourSeconds());
        armourBar.SetSecondsOfArmour(worldController.worldData.difficulty.secondsPerSection);

        //Add the initial position for the village. Maybe making a call to the worldmanager to find a valid position. Also maybe, calling the parsing world

    }
}