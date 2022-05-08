using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public DifficultyData difficulty;
    public IntensityData intensity;
    [SerializeField] private WorldStateController _controller;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private GridMovement _gridMovement;
    [SerializeField] private MapSnapping _mapSnapping;
    [SerializeField] private GameObject _map;
    // Start is called before the first frame update
    void Start()
    {
        _gridManager.Initialize(difficulty.villagesAmount);
        _controller.Initialize(difficulty, intensity);

        float mapCellSize = ComputeMapCellSize(_gridManager.CellSize);
        _mapSnapping.Initialize(mapCellSize, _gridManager.WorldRadius, _map.transform);
        _gridMovement.Initialize(_gridManager, _mapSnapping);
    }

    private float ComputeMapCellSize(int cellSize)
    {
        Mesh mapMesh = _map.GetComponent<MeshFilter>().mesh;
        Vector3 mapDimensions = mapMesh.bounds.size;
        int worldSize = _gridManager.WorldRadius * 2 + 1;
        return mapDimensions.x * cellSize * _map.transform.localScale.x / worldSize;
    }
}
