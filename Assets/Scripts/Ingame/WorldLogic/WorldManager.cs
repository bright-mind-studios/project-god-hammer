using System.Collections;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public DifficultyData difficulty;
    public IntensityData intensity;
    [SerializeField][Range(1, 60)] private int _secondsToStart = 30; 
    [SerializeField] private WorldStateController _controller;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private GridMovement _gridMovement;
    [SerializeField] private MapSnapping _mapSnapping;
    [SerializeField] private MinigameManager _minigameManager;
    [SerializeField] private GameObject _map;
    // Start is called before the first frame update
    void Start()
    {
        // Leer datos del gamemanager:
        if(GameManager.Instance != null)
        {
            Debug.Log("Datos leidos del GameManager");
            difficulty = GameManager.Instance.Settings.difficulty;
            intensity = GameManager.Instance.Settings.intensity;
        }

        _gridManager.Initialize(difficulty.villagesAmount);
        _controller.Initialize(difficulty, intensity);
        _minigameManager.Initialize(_gridManager);

        float mapCellSize = ComputeMapCellSize(_gridManager.CellSize);
        _mapSnapping.Initialize(mapCellSize, _gridManager.WorldRadius, _map.transform);
        _gridMovement.Initialize(_gridManager, _mapSnapping, _minigameManager);
        _gridManager.LoadEntitiesIcons(_mapSnapping);

        StartCoroutine(StartGame());
    }

    private float ComputeMapCellSize(int cellSize)
    {
        Mesh mapMesh = _map.GetComponent<MeshFilter>().mesh;
        Vector3 mapDimensions = mapMesh.bounds.size;
        int worldSize = _gridManager.WorldRadius * 2 + 1;
        return mapDimensions.x * cellSize * 0.2f / worldSize;
    }

    public IEnumerator StartGame()
    {
        var current_time = 0f;
        while (current_time < _secondsToStart)
        {
            current_time += Time.deltaTime;
            yield return null;
        }
        _controller.StartGame();
    }
}
