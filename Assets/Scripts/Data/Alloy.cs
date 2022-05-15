using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Alloy", menuName = "project-god-hammer/Alloy", order = 3)]
public class Alloy : Element
{
    public Metal primaryMetal, secondaryMetal;

    public Color primaryColor, secondaryColor;

    public override int GetLevel() => primaryMetal.GetLevel() + secondaryMetal.GetLevel();

    public override Color GetPrimaryColor() => primaryColor;

    public override Color GetSecondaryColor() => secondaryColor;
}
