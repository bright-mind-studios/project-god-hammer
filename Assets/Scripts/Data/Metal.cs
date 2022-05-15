using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Metal", menuName = "project-god-hammer/Metal", order = 2)]
public class Metal : Element
{
    public enum Tier{
        low = 1,
        mid = 2,
        high = 3,
        special = 0
    }

    public Tier tier;

    public Color color;

    public override Color GetPrimaryColor() => color;

    public override Color GetSecondaryColor() => color;

    public override int GetLevel() => (int) tier;

    
}
