using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStation : WorkStation
{
    public List<Resource> resources;

    [SerializeField] private ButtonInteractable button;

    public new void OnEnable(){
        base.OnEnable();
        button.OnPressButton += DropOutput;
    }

    public new void OnDisable(){
        base.OnDisable();
        button.OnPressButton -= DropOutput;
    }

    public override bool IsValidResource(Resource resource)
    {
        return true;
    }

    public override void ProcessResource(Resource resource)
    {
        resources.Add(resource);
    }   

    private void DropOutput()
    {
        if(resources.Count > 0){
            Resource res = resources[0];
            resources.RemoveAt(0);
            ReleaseOutputResource(res, 0.1f);
        }            
    }
    
}
