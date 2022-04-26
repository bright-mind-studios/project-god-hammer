using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorkStation : Station
{
    public readonly static int inputSize = 1;       // Items máximos de entrada
    [SerializeField] private InputZone inputZone;   
    [SerializeField] private OutputZone outputZone;      
    public List<ResourceItem<Resource>> store;                        // Objetos dentro de la estación
    
    protected void TriggerInputZone(bool active)
    {
        inputZone.gameObject.SetActive(active);
    }

    private void OnEnable() 
    {
        inputZone.OnTakeResource += OnTakeInputResource;
    }

    private void OnDisable() 
    {
        inputZone.OnTakeResource -= OnTakeInputResource;
    }
    public void OnTakeInputResource(Resource resource)
    {
        if(IsValidResource(resource))
        {
            ProcessResource(resource);
        }
        else
        {
            ReleaseOutputResource(resource);
        }
    }

    public abstract bool IsValidResource(Resource resource);
    public abstract void ProcessResource(Resource resource);

    public void ReleaseOutputResource(Resource resource)
    {
        outputZone.OutputResourceItem(resource);
    }    
}
