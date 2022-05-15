using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private ResourceStation resourceStation;
    [SerializeField] private GameObject _spawnPlace;
    [SerializeField] private int _secondsToRespawnResource;
    private EnvironmentEntity _entity;
    private GridManager _gridManager;
    private GameObject _minigamePrefab;
    private int _uses;
    private int _index;

    public void Initialize(GridManager gridManager)
    {
        _gridManager = gridManager;
        resourceStation.OnUseEndEvent.AddListener(OnUseEnd);
    }

    public void LoadAndStart(EnvironmentEntity entity, int index)
    {
        if (entity == null) return;

        _index = index;
        _entity = entity;
        _uses = _entity.resourceUses;

        if (_entity.minigamePrefab != null) _minigamePrefab = Instantiate(_entity.minigamePrefab, _spawnPlace.transform, false);

        _entity.minigameEvents.OnResourceLoad(resourceStation);
        UseResource();
    }

    public void Unload()
    {
        if (_entity == null) return;
        //Limpia las variables y lanza evento final
        if (_minigamePrefab != null) Destroy(_minigamePrefab);
        _entity.minigameEvents.OnResourceUnload(resourceStation); // Que se guarde valor en la corrutina, crear metodo de spawn aqui - Unload quitar estacion, parar corrutinas, etc
        _entity = null;
        _index = -1;

    }

    public void UseResource()
    {
        if (_entity == null) return;

        _uses -= _uses;
        _entity.minigameEvents.OnResourceUse(resourceStation);
    }

    private void OnUseEnd()
    {
        
        if (_uses == 0)
        {
            _entity.minigameEvents.OnResourceDestroy(this); // que llame a la reaparicion
            Unload();
        }
    }

    public void ClearResourceAndRespawn()
    {
        _gridManager.DestroyEntityOf(_index);
        _index = -1;
        StartCoroutine(RespawnEvent());
    }

    private IEnumerator RespawnEvent()
    {
        EnvironmentEntity entity = _entity;
        var current_time = 0f;
        while (current_time < _secondsToRespawnResource)
        {
            current_time += Time.deltaTime;
            yield return null;
        }
        _gridManager.PlaceEntity(entity);
    }
}
