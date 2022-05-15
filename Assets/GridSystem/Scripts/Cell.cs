using UnityEngine;

public class Cell : MonoBehaviour
{
    private int _x, _z;
    private float _cellSize;
    private Vector3 _worldPosition;
    private GameObject _environmentEntity;
    private EnvironmentEntity _entity;

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

    public GameObject PlaceEntity(EnvironmentEntity entity)
    {
        _entity = entity;
        GameObject entityHolder = new GameObject("entity");
        entityHolder.transform.parent = gameObject.transform;
        entityHolder.transform.position = _worldPosition;
        entityHolder.transform.localScale = Vector3.one;
        _environmentEntity = Instantiate(entity.prefab,entityHolder.transform,true);
        _environmentEntity.transform.localScale = entity.localScale;
        _environmentEntity.transform.localPosition = entity.localPosition;
        int rot = Random.Range(0, 4);
        entityHolder.transform.Rotate(0f, 90f * rot, 0f, Space.World);

        if (entity.terrainModifier)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("DefaultTerrain"))
                {
                    Destroy(child.gameObject);
                    break;
                }
            }
        }

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
        _entity = null;
    }

    public EnvironmentEntity GetEntity()
    {
        return _entity;
    }

    public GameObject GetEntityInstance()
    {
        return _environmentEntity;
    }

    public bool IsResourceProvider()
    {
        return _entity != null && _entity.resourceProvider;
    }
}
