using UnityEngine;

public class Cell : MonoBehaviour
{
    private int _x, _z;
    private float _cellSize;
    private Vector3 _worldPosition;
    private GameObject _environmentEntity;

    public int X { get { return _x; } private set { } }
    public int Z { get { return _z; } private set { } }

    // Start is called before the first frame update
    public void Generate(int x, int z, int cellSize)
    {
        _x = x;
        _z = z;
        _cellSize = cellSize;

        _worldPosition = new Vector3(_x * _cellSize, 0, _z * _cellSize);
        GetComponent<Transform>().position = _worldPosition;
    }

    private void SetEntityIcon(GameObject parent ,Sprite sprite, Color color)
    {
        // Minimap Icon
        GameObject iconMinimap = new GameObject("MinimapIcon");
        iconMinimap.transform.SetParent(parent.transform, true);
        iconMinimap.layer = LayerMask.NameToLayer("MinimapGrid");
        iconMinimap.transform.localScale = new Vector3(1f * _cellSize/3, 1f * _cellSize/3, 1f);
        iconMinimap.transform.Rotate(-90f, 0f, 0f, Space.World);
        iconMinimap.transform.position = new Vector3(parent.transform.position.x, GameObject.FindGameObjectWithTag("MinimapCamera").transform.position.y-1f, parent.transform.position.z);
        SpriteRenderer icon = iconMinimap.AddComponent<SpriteRenderer>();
        icon.sprite = sprite;
        icon.color = color;
    }

    public GameObject PlaceEntity(EnvironmentEntity entity)
    {
        GameObject entityHolder = new GameObject("entity");
        entityHolder.transform.parent = gameObject.transform;
        entityHolder.transform.position = _worldPosition;
        entityHolder.transform.localScale = Vector3.one;
        _environmentEntity = Instantiate(entity.prefab,entityHolder.transform,true);
        _environmentEntity.transform.localScale = entity.localScale;
        _environmentEntity.transform.localPosition = entity.localPosition;
        int rot = Random.Range(0, 4);
        entityHolder.transform.Rotate(0f, 90f * rot, 0f, Space.World);
        SetEntityIcon(entityHolder, entity.mapSprite, new Color(entity.placeholderColor.r, entity.placeholderColor.g, entity.placeholderColor.b));
        return _environmentEntity;
    }

    public bool IsAvailable()
    {
        return _environmentEntity == null;
    }

    public void DestroyEntity()
    {
        if (_environmentEntity == null) return;

        Destroy(_environmentEntity);
        _environmentEntity = null;
    }
}
