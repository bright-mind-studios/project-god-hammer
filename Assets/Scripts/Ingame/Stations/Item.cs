using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Resource resource;

    public void SetResource(Resource resource){
        this.resource = resource;        
    }
}
