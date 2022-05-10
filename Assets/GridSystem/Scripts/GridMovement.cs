using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private GameObject cloudManager;
    [SerializeField] private GameObject _spawnPlace;
    private GameObject _minigame;

    private GridManager _gridManager;
    private MapSnapping _mapSnapping;
    private Coroutine _currentMove;

    private int _index;

    public void Initialize(GridManager gridManager, MapSnapping mapSnapping)
    {
        _gridManager = gridManager;
        _mapSnapping = mapSnapping; 
    }

    public void Move()
    {
        _index = _mapSnapping.GetDeployedCellIndex();

        if (!_gridManager.CheckIndexOf(_index)) return;

        Vector3 newPosition = _gridManager.GetPositionOf(_index);
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
        DestroyMinigame();

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
        SpawnItem();
        
        _mapSnapping.EnableKinetic(false);
        yield return null;
    }

    private void DestroyMinigame()
    {
        if (_minigame != null) Destroy(_minigame);
    }

    private void SpawnItem()
    {
        GameObject minigame = _gridManager.GetMinigame(_index);

        if (minigame == null) return;

        _minigame = Instantiate(minigame,_spawnPlace.transform, false);
    }
}
