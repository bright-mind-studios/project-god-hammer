using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldStatus : Status
{
    private bool _deathVillage;
    public bool DeathVillage{ get { return _deathVillage; } private set { _deathVillage = value; } }

    public WorldStatus(GameObject id, bool deathVillage): base(id)
    {
        DeathVillage = deathVillage;
    }
}


public class WorldStateController : BaseStateController
{
    public struct WorldData
    {
        public DifficultyData difficulty;
        public IntensityData intensity;
        public int activeRequests;
        public int aliveVillages;
    }
    public EnvironmentEntity villageEntity;
    public WorldData worldData;

    private List<VillageStateController> _villageControllers;
    public int VillagesCount{get{ return _villageControllers.Count; } private set{ }}

    public void Initialize(DifficultyData difficulty, IntensityData intensity)
    {
        worldData = new WorldData
        {
            difficulty = difficulty,
            intensity = intensity
        };

        GenerateVillages();

        foreach (var villageController in _villageControllers)
        {
            villageController.InitializeStateMachine(true);
        }
    }

    public void StartGame()
    {
        InitializeStateMachine(true);
    }

    private void GenerateVillages()
    {
        GridManager gridManager = FindObjectOfType<GridManager>();

        _villageControllers = new List<VillageStateController>();

        for (int i = 1; i <= worldData.difficulty.villagesAmount; i++)
        {
            GameObject village = gridManager.PlaceEntity(villageEntity); //Instantiate(villagePrefab, new Vector3(0 + 3*(i-1),0,0), Quaternion.identity, villages.transform); // Change this to 0,0,0 when finished location system
            _villageControllers.Add(village.GetComponent<VillageStateController>());
        }
    }

    public override void InitializeStateMachine(bool activate)
    {
        base.InitializeStateMachine(activate);
        worldData.aliveVillages = worldData.difficulty.villagesAmount;
    }

    protected override void OnExitState()
    {
        stateBoolVariable = false;
    }

    public void DeleteVillage(VillageStateController village)
    {
        _villageControllers.Remove(village);
    }

    public VillageStateController GetVillage(int idx)
    {
        return _villageControllers[idx];
    }
}
