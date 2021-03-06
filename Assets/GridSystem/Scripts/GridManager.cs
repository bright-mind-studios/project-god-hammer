using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField][Range(1, 10)] private int _worldRadius;
    [SerializeField][Range(1, 10)] private int _cellSize;
    [SerializeField] private EnvironmentEntity[] _environmentEntities;
    [SerializeField] private GameObject _defaultTerrainPrefab;
    [SerializeField] private Material[] _terrainMaterials;
    [SerializeField] private Sprite _minimapSprite;
    [SerializeField] private Color[] _minimapColors;


    
    private GameObject _world;
    private Cell[] _gridMap;
    private int _gridSize;
    private int _nonSpawnableCells;
    private HashSet<int> _availableIndexes;

    public int CellSize { get { return _cellSize; } private set { } }
    public int WorldRadius { get { return _worldRadius; } private set { } }

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
                MapSnapping mapSnapping = GameObject.FindObjectOfType<MapSnapping>();
                if (mapSnapping.Enabled) mapSnapping.SetIcon((int)GetXZ(cellIndex).x, (int)GetXZ(cellIndex).y, entity.mapSprite);
            }

        } while (gameObject == null);

        return gameObject;
    }

    private void LoadWorld(int worldSize)
    {
        int colorIdx = 0;

        for (int i = 0; i < worldSize; i++)
        {
            Vector2 position = GetXZ(i);
            
            _availableIndexes.Add(i);
            _gridMap[i] = GenerateCell((int)position[0], (int)position[1], colorIdx);

            colorIdx = (colorIdx + 1) % _minimapColors.Length;
        }
        //SetTerrain(_gridMap[(int)_gridMap.Length/2].gameObject);
    }

    private Cell GenerateCell(int x, int z, int colorIdx)
    {
        GameObject cellObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        cellObject.name = "Cell_[" + x + ", " + z + "]";
        cellObject.transform.SetParent(_world.transform, false);
        cellObject.transform.localScale = new Vector3(_cellSize / 10f, 1, _cellSize / 10f);
        cellObject.GetComponent<Renderer>().material = _terrainMaterials[0];

        Cell cell = cellObject.AddComponent<Cell>();
        cell.Generate(x, z, _cellSize);

        SetTerrain(cellObject);
        SpawnEntity(cell);
        SetMinimapGridIcon(cellObject, colorIdx);

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

    private void SetMinimapGridIcon(GameObject cellObject, int colorIdx)
    {
        // Minimap Icon
        GameObject iconMinimap = new GameObject("MinimapIcon");
        iconMinimap.transform.SetParent(cellObject.transform, false);
        iconMinimap.layer = LayerMask.NameToLayer("MinimapGrid");
        iconMinimap.transform.localScale = new Vector3(1f * _cellSize, 1f * _cellSize, 1f);
        iconMinimap.transform.Rotate(-90f, 0f, 0f, Space.World);
        iconMinimap.transform.position = new Vector3(iconMinimap.transform.position.x, GameObject.FindGameObjectWithTag("MinimapCamera").transform.position.y - 1.5f, iconMinimap.transform.position.z);
        SpriteRenderer icon = iconMinimap.AddComponent<SpriteRenderer>();
        icon.sprite = _minimapSprite;
        icon.color = new Color(_minimapColors[colorIdx].r, _minimapColors[colorIdx].g, _minimapColors[colorIdx].b, 0.75f);
    }

    private void SetTerrain(GameObject cellObject)
    {
        GameObject terrain = Instantiate(_defaultTerrainPrefab, cellObject.transform);
        terrain.name = "Terreno base";
        terrain.layer = LayerMask.NameToLayer("Minimap");
        terrain.tag = "DefaultTerrain";
        terrain.transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
        terrain.transform.localPosition = new Vector3(0f, -0.38f, 0f);
        int rot = Random.Range(0, 4);
        terrain.transform.Rotate(0f, 90f * rot, 0f, Space.World);
    }

    public bool CheckIndexOf(int index)
    {
        return 0 <= index && index < _gridSize * _gridSize;
    }

    public Vector3 GetPositionOf(int index)
    {
        return _gridMap[index].gameObject.transform.position;
    }

    public EnvironmentEntity GetCellEntity(int index)
    {
        return _gridMap[index].GetEntity();
    }

    public GameObject GetCellInstance(int index)
    {
        return _gridMap[index].GetEntityInstance();
    }

    public void LoadEntitiesIcons(MapSnapping mapSnapping)
    {
        foreach (Cell cell in _gridMap)
        {
            if (!cell.IsResourceProvider()) continue;
            EnvironmentEntity entity = cell.GetEntity();
            mapSnapping.SetIcon(cell.X, cell.Z, entity.mapSprite);
        }
    }

    public void DestroyEntityOf(int index)
    {
        if (!CheckIndexOf(index)) return;

        _gridMap[index].DestroyEntity();
        GameObject.FindObjectOfType<MapSnapping>().DeleteIcon(index);
    }
}
