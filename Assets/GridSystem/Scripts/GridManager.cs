using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField][Range(1, 10)] private int _worldRadius;
    [SerializeField][Range(1, 10)] private int _cellSize;
    [SerializeField] private Material[] _terrainMaterials;
    [SerializeField] private EnvironmentEntity[] _environmentEntities;

    private GameObject _world;
    private Cell[] _gridMap;
    private int _gridSize;

    private void Start()
    {
        int worldSize;
        
        _gridSize = _worldRadius * 2 + 1;
        worldSize = _gridSize * _gridSize;
        _gridMap = new Cell[worldSize];
        _world = new GameObject("WorldGrid");
        LoadWorld(worldSize);
    }

    private void LoadWorld(int worldSize)
    {
        int x, z;

        for (int i = 0; i < worldSize; i++)
        {
            x = i / _gridSize;
            z = i % _gridSize;
            
            _gridMap[i] = GenerateCell(x, z);
        }
    }

    private Cell GenerateCell(int x, int z)
    {
        GameObject cellObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        cellObject.name = "Cell_[" + x + ", " + z + "]";
        cellObject.transform.SetParent(_world.transform, false);
        cellObject.transform.localScale = new Vector3(0.2f, 1, 0.2f);
        cellObject.GetComponent<Renderer>().material = _terrainMaterials[0];

        Cell cell = cellObject.AddComponent<Cell>();
        cell.Generate(x, z, _cellSize);
        cell.PlaceEntity(_environmentEntities[0]);
        return cell;
    }
}
