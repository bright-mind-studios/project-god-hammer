using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private GridManager _gridManager;
    private MapSnapping _mapSnapping;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _speed = 0f; 
    public void Initialize(GridManager gridManager, MapSnapping mapSnapping)
    {
        _gridManager = gridManager;
        _mapSnapping = mapSnapping; 
    }

    //public void Update()
    //{
    //    if (_speed == 0) return;

    //    transform.position = Vector3.Lerp(_startPosition, _endPosition, _speed * Time.deltaTime);

    //    if (transform.position.Equals(_endPosition)) _speed = 0f;

    //}

    public void Move()
    {
        Vector3 newPosition = _gridManager.GetPositionOf(_mapSnapping.GetDeployedCellIndex());
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        //_startPosition = transform.position;
        //_endPosition = newPosition;
        //_speed = 1f;
    }
}
