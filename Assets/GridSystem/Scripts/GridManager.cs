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
    private int _nonSpawnableCells;
    private HashSet<int> _availableIndexes;

    public void Initialize(int nonSpawnableCells)
    {
        int worldSize;
        _availableIndexes = new HashSet<int>();
        _gridSize = _worldRadius * 2 + 1;
        worldSize = _gridSize * _gridSize;
        _gridMap = new Cell[worldSize];
        _world = new GameObject("WorldGrid");
        _nonSpawnableCells = nonSpawnableCells;

        LoadWorld(worldSize);
    }

    public GameObject PlaceEntity(EnvironmentEntity entity)
    {
        if (_availableIndexes.Count < 0) return null;

        GameObject gameObject = null;
        int cellIndex = 0;

        do
        {
            cellIndex = (Random.Range(0, _gridMap.Length) + _gridMap.Length / Random.Range(2, 5)) % _gridMap.Length;
            if (_availableIndexes.Contains(cellIndex))
            {
                gameObject = _gridMap[cellIndex].PlaceEntity(entity);
                _availableIndexes.Remove(cellIndex);
            }

        } while (gameObject == null);

        return gameObject;
    }

    private void LoadWorld(int worldSize)
    {
        for (int i = 0; i < worldSize; i++)
        {
            Vector2 position = GetXZ(i);
            
            _availableIndexes.Add(i);
            _gridMap[i] = GenerateCell((int)position[0], (int)position[1]);
        }
    }

    private Cell GenerateCell(int x, int z)
    {
        GameObject cellObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        cellObject.name = "Cell_[" + x + ", " + z + "]";
        cellObject.transform.SetParent(_world.transform, false);
        cellObject.transform.localScale = new Vector3(_cellSize / 10f, 1, _cellSize / 10f);
        cellObject.GetComponent<Renderer>().material = _terrainMaterials[0];

        Cell cell = cellObject.AddComponent<Cell>();
        cell.Generate(x, z, _cellSize);

        SpawnEntity(cell);

        return cell;
    }

    private void SpawnEntity(Cell cell)
    {
        if (CheckAvailability())
        {
            GameObject gameObject = null;
            int ini = Random.Range(0, _environmentEntities.Length);
            int cur = ini;
            do
            {
                if (Random.Range(0f, 1f) <= _environmentEntities[cur].spawnChance)
                {
                    gameObject = cell.PlaceEntity(_environmentEntities[cur]);
                }

                cur = (cur + 1) % _environmentEntities.Length;
            } while (gameObject == null && ini != cur);
            
            if (gameObject != null)
            {
                _availableIndexes.Remove(cell.X * _gridSize + cell.Z);
            }
        }
    }

    private Vector2 GetXZ(int index)
    {
        int x = index / _gridSize;
        int z = index % _gridSize;

        return new Vector2(x, z);
    }

    private bool CheckAvailability()
    {
        return _availableIndexes.Count > _nonSpawnableCells;
    }
}
