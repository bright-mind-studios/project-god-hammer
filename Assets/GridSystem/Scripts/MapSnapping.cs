using UnityEngine;

public class MapSnapping : MonoBehaviour
{
    private float _cellSize = 0;
    private int _worldRadius;
    private float _reciprocal;
    private Vector2 _basePosition;
    private Transform _map;

    public void Initialize(float cellSize, int worldRadius, Transform map)
    {
        _cellSize = cellSize;
        _reciprocal = 1f / _cellSize;
        _worldRadius = worldRadius;
        _map = map;
        transform.position = GetSnappedPosition();
        _basePosition = new Vector2(_map.transform.position.x, _map.transform.position.z);
    }

    public void Update()
    {
        if (_cellSize == 0) return;
        _basePosition = new Vector2(_map.transform.position.x, _map.transform.position.z);
        Vector3 nextPosition = GetSnappedPosition();
        nextPosition.x = Mathf.Clamp(nextPosition.x, _basePosition.x - _worldRadius * _cellSize, _basePosition.x + _worldRadius * _cellSize);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _basePosition.y - _worldRadius * _cellSize, _basePosition.y + _worldRadius * _cellSize);
        transform.position = nextPosition;
    }

    private Vector3 GetSnappedPosition()
    {
        return new Vector3(
            Mathf.Round(transform.position.x * _reciprocal) / _reciprocal,
            transform.position.y,
            Mathf.Round(transform.position.z * _reciprocal) / _reciprocal
            );
    }

    public int GetDeployedCellIndex()
    {
        int x_world = (int)Mathf.Round((transform.position.x - _basePosition.x) / _cellSize) + _worldRadius; // X is the X coordinate on real world grid
        int y_world = (int)Mathf.Round((transform.position.z - _basePosition.y) / _cellSize) + _worldRadius; // Z is the Y coordinate on real world grid
        int worldSize = _worldRadius * 2 + 1;
        return x_world * worldSize + y_world;
    }
}
