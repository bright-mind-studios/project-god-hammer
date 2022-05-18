using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalItem : ResourceItem
{
    private MaterialPropertyBlock mpb;

    public void SetMetal(Metal metal){
        mpb = new MaterialPropertyBlock();
        this.resource = metal;
        mpb.SetColor("_BaseColor", metal.color);
        GetComponentInChildren<Renderer>().SetPropertyBlock(mpb);
    }
}
