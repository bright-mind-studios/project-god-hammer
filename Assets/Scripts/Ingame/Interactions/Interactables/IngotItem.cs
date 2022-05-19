using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotItem : ResourceItem
{
    private MaterialPropertyBlock mpb;

    [ContextMenu("TestColor")]
    public void SetMetal(Element element){
        mpb = new MaterialPropertyBlock();
        this.resource = element;
        mpb.SetColor("Color_1", element.GetPrimaryColor());
        mpb.SetColor("Color_2", element.GetSecondaryColor());
        GetComponentInChildren<Renderer>().SetPropertyBlock(mpb);            
    }
}
