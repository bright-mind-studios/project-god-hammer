using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : GrabInteractable
{
    public Weapon weapon;

    public MeshRenderer M1;
    public MeshRenderer M2;

    private MaterialPropertyBlock mpb1, mpb2;


    public void SetElement(Element element)
    {
        mpb1 = new MaterialPropertyBlock();
        mpb2 = new MaterialPropertyBlock();
        weapon.element = element;
        mpb1.SetColor("_BaseColor", element.GetPrimaryColor());
        mpb2.SetColor("_BaseColor", element.GetSecondaryColor());
        M1.SetPropertyBlock(mpb1);
        M2.SetPropertyBlock(mpb2);
    }
}
