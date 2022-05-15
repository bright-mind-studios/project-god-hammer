using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotItem : ResourceItem
{
    private MaterialPropertyBlock mpb;
    public void SetMetal(Element element){
        mpb = new MaterialPropertyBlock();
        this.resource = element;
        mpb.SetColor("_BaseColor", element.GetPrimaryColor());
        mpb.SetColor("_BaseColor", element.GetSecondaryColor());
        GetComponentInChildren<Renderer>().SetPropertyBlock(mpb);            
    }
}
