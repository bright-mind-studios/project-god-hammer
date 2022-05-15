using System.Collections.Generic;
using UnityEngine;

public class MapSnapping : MonoBehaviour
{

    [SerializeField] private float _controllerHeight = 0.1259f;
    [SerializeField] private Sprite _minimapSprite;
    [SerializeField] private Color _minimapColors;

    public bool Enabled = false;

    private float _cellSize = 0;
    private int _worldRadius;
    private float _reciprocal;
    private Vector2 _basePosition;
    private Transform _map;
    private GameObject _mapIndicator, _icons;
    private Dictionary<int, GameObject> _entityIcons;

    private bool kineticEnabled = false;

    private void Awake()
    {

        _entityIcons = new Dictionary<int, GameObject>();
        _icons = new GameObject("entityIcons");
    }

    public void Initialize(float cellSize, int worldRadius, Transform map)
    {
        _cellSize = cellSize;
        _reciprocal = 1f / _cellSize;
        _worldRadius = worldRadius;
        _map = map;
        _icons.transform.SetParent(_map);
        transform.position = GetSnappedPosition();
        _basePosition = new Vector2(_map.transform.position.x, _map.transform.position.z);
        SetMinimapIndicator(_map.gameObject);
        Enabled = true;
    }

    public void Update()
    {
        if (!kineticEnabled)
            UpdateSnappedPosition();
    }

    private void UpdateSnappedPosition()
    {
        if (_cellSize == 0) return;
        _basePosition = new Vector2(_map.transform.position.x, _map.transform.position.z);
        Vector3 nextPosition = GetSnappedPosition();
        nextPosition.x = Mathf.Clamp(nextPosition.x, _basePosition.x - _worldRadius * _cellSize, _basePosition.x + _worldRadius * _cellSize);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _basePosition.y - _worldRadius * _cellSize, _basePosition.y + _worldRadius * _cellSize);
        transform.position = nextPosition;
        transform.localPosition = new Vector3(transform.localPosition.x, _controllerHeight, transform.localPosition.z);
        _mapIndicator.transform.position = new Vector3(transform.position.x -0.01f, _map.position.y + 0.01f, transform.position.z);
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
        UpdateSnappedPosition();
        int x_world = (int)Mathf.Round((transform.position.x - _basePosition.x) / _cellSize) + _worldRadius; // X is the X coordinate on real world grid
        int y_world = (int)Mathf.Round((transform.position.z - _basePosition.y) / _cellSize) + _worldRadius; // Z is the Y coordinate on real world grid
        int worldSize = _worldRadius * 2 + 1;
        return x_world * worldSize + y_world;
    }

    private void SetMinimapIndicator(GameObject parent)
    {
        // Minimap Icon
        _mapIndicator = new GameObject("MinimapIndicator");
        _mapIndicator.transform.SetParent(parent.transform, false);
        _mapIndicator.layer = LayerMask.NameToLayer("MinimapGridIndicator");
        _mapIndicator.transform.localScale = new Vector3(1f * _cellSize* 0.3f, 1f * _cellSize * 0.3f, 1f);
        _mapIndicator.transform.Rotate(0f, 0f, 0f, Space.World);
        _mapIndicator.transform.position = new Vector3(transform.position.x, _mapIndicator.transform.position.y, transform.position.z);
        SpriteRenderer icon = _mapIndicator.AddComponent<SpriteRenderer>();
        icon.sprite = _minimapSprite;
        icon.color = new Color(_minimapColors.r, _minimapColors.g, _minimapColors.b, 0.65f);
    }

    public void EnableKinetic(bool enabled)
    {
        kineticEnabled = enabled;
    }

    public void SetIcon(int x, int y, Sprite sprite)
    {
        int index = GetIndex(x, y);
        // Minimap Icon
        GameObject iconMinimap = new GameObject(sprite.name+"_"+index);
        iconMinimap.transform.SetParent(_icons.transform, false);
        iconMinimap.layer = LayerMask.NameToLayer("Minimap");
        iconMinimap.transform.localScale = new Vector3(1f * _cellSize / 4, 1f * _cellSize / 4, 1f);
        iconMinimap.transform.Rotate(-90f, 0f, 90f, Space.World);
        iconMinimap.transform.position = new Vector3((_basePosition.x - _worldRadius * _cellSize) + x * _cellSize, 
            _map.transform.position.y+0.001f,
            (_basePosition.y - _worldRadius * _cellSize) + y * _cellSize);
        SpriteRenderer icon = iconMinimap.AddComponent<SpriteRenderer>();
        icon.sprite = sprite;
        _entityIcons.Add(index, iconMinimap);
    }

    private int GetIndex(int x, int y)
    {
        return x * (_worldRadius * 2 + 1) + y;
    }

    public void DeleteIcon(int index)
    {
        if (_entityIcons.ContainsKey(index))
        {
            Destroy(_entityIcons[index]);
            _entityIcons.Remove(index);
        }
    }
}
