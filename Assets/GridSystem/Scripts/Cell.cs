using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private int _x, _z;
    private float _cellSize;
    private Vector3 _worldPosition;
    private GameObject _environmentEntity;

    // Start is called before the first frame update
    public void Generate(int x, int z, int cellSize)
    {
        _x = x;
        _z = z;
        _cellSize = cellSize;

        _worldPosition = new Vector3(_x * _cellSize, 0, _z * _cellSize);
        GetComponent<Transform>().position = _worldPosition;
    }

    public void PlaceEntity(EnvironmentEntity entity)
    {
        _environmentEntity = Instantiate(entity.prefab,gameObject.transform,true);
        Vector3 bounds =_environmentEntity.GetComponent<MeshRenderer>().bounds.size;
        _environmentEntity.transform.position = new Vector3(_worldPosition.x, bounds.y/2, _worldPosition.z);
    }
}
