using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private ResourceStation resourceStation;
    [SerializeField] private GameObject _spawnPlace;
    private EnvironmentEntity _entity;
    private GameObject _minigamePrefab;
    private int _uses;

    private void Awake()
    {
        resourceStation.OnUseEndEvent.AddListener(OnUseEnd);
    }
    public void LoadAndStart(EnvironmentEntity entity)
    {
        if (entity == null) return;

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
            _entity.minigameEvents.OnResourceDestroy(); // que llame a la reaparicion
            Unload();
        }
    }
}
