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

    public override void ProcessResource(Resource resource)
    {
        TriggerInputZone(false);
        // Generar el arma con el molde
        //ReleaseOutputResource(...)
    }   
}
