using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Metal", menuName = "project-god-hammer/Metal", order = 2)]
public class Metal : Element
{
    public enum Tier{
        low,
        mid,
        high,
        special
    }

    public Color color;

    public override Color GetPrimaryColor() => color;

    public override Color GetSecondaryColor() => color;
    public Tier tier;
}
