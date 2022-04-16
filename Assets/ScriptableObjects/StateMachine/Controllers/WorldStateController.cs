using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateController : BaseStateController
{
    private VillageStateController[] _villageControllers;

    private void Start()
    {
        _villageControllers = FindObjectsOfType<VillageStateController>();

        foreach (var villageController in _villageControllers)
        {
            villageController.InitializeStateMachine(true); // Maybe calling before the get for positioning and then passing through the village
        }
    }

    public VillageStateController GetVillage()
    {
        return _villageControllers[0];
    }
}
