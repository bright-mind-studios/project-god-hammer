using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MetalFragment : MonoBehaviour
{   
    public Metal metal; 
    private MaterialPropertyBlock mpb;

    public void SetMetal(Metal metal){
        mpb = new MaterialPropertyBlock();
        this.metal = metal;
        mpb.SetColor("_BaseColor", metal.color);
        GetComponentInChildren<Renderer>().SetPropertyBlock(mpb);
    }
}
