using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateController : BaseStateController
{
    [System.Serializable]
    public struct WorldData
    {
        public DifficultyData difficulty;
    }
    public WorldData worldData;

    private VillageStateController[] _villageControllers;


    private void Start()
    {
        _villageControllers = FindObjectsOfType<VillageStateController>();

        foreach (var villageController in _villageControllers)
        {
            villageController.InitializeStateMachine(true); // Maybe calling before the get for positioning and then passing through the village
        }
    }
}
