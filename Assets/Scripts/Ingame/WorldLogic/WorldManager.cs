using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public DifficultyData difficulty;
    public IntensityData intensity;
    [SerializeField] private WorldStateController _controller;
    [SerializeField] private GridManager _gridManager;
    // Start is called before the first frame update
    void Start()
    {
        _gridManager.Initialize(difficulty.villagesAmount);
        _controller.Initialize(difficulty, intensity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
