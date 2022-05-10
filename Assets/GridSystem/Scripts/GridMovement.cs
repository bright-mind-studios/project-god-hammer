using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private GameObject cloudManager;

    private GridManager _gridManager;
    private MapSnapping _mapSnapping;
    private Coroutine _currentMove;

    public void Initialize(GridManager gridManager, MapSnapping mapSnapping)
    {
        _gridManager = gridManager;
        _mapSnapping = mapSnapping; 
    }

    public void Update()
    {
        //if (_speed == 0) return;

        //transform.position = Vector3.Lerp(_startPosition, _endPosition, _speed * Time.deltaTime);

        //if (transform.position.Equals(_endPosition)) _speed = 0f;

    }

    public void Move()
    {
        int index = _mapSnapping.GetDeployedCellIndex();

        if (!_gridManager.CheckIndexOf(index)) return;

        Vector3 newPosition = _gridManager.GetPositionOf(index);
        Vector3 startPosition;
        Vector3 endPosition;
        //transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        startPosition = transform.position;
        endPosition = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        if (_currentMove != null) StopCoroutine(_currentMove);
        _currentMove = StartCoroutine(MoveFromTo(startPosition, endPosition));
    }

    IEnumerator MoveFromTo(Vector3 currentPosition, Vector3 newPosition)
    {
        float elapsedTime = 0;
        float travelTime = 3f;

        _mapSnapping.EnableKinetic(true);

        while (elapsedTime < travelTime)
        {
            transform.position = Vector3.Lerp(currentPosition, newPosition, (elapsedTime / travelTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = newPosition;

        
        _mapSnapping.EnableKinetic(false);
        yield return null;
    }
}
