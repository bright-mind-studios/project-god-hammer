using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotItem : ResourceItem
{
    private MaterialPropertyBlock mpb;
    public void SetMetal(Element element){
        mpb = new MaterialPropertyBlock();
        this.resource = element;
        if(element is Metal metal)
        {
            Debug.Log("EEEEEEEE");
            mpb.SetColor("_BaseColor", metal.color);
            GetComponentInChildren<Renderer>().SetPropertyBlock(mpb);
        }
        else if(element is Alloy alloy)
        {

        }
            
    }
}
