using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldStation : WorkStation
{
   
    [SerializeField] private Mold mold;    

    public override bool IsValidResource(Resource resource)
    {
        return resource is Metal;
    }

    private new void OnEnable() 
    {
        base.OnEnable();
        mold.OnChangeState += inputZone.SetActived;
    }
 
    private new void OnDisable()
    {
        base.OnDisable();
        mold.OnChangeState -= inputZone.SetActived;
    }

    public override void ProcessResource(Resource resource)
    {
        TriggerInputZone(false);
        // Generar el arma con el molde
        //ReleaseOutputResource(...)
    }   
}
