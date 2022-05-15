using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : Resource
{
    public abstract Color GetPrimaryColor();
    public abstract Color GetSecondaryColor();

    public abstract int GetLevel();
}
