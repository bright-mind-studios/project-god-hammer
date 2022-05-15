using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinigameEvents : MonoBehaviour
{
    public abstract void OnResourceLoad(ResourceStation resourceStation);
    public abstract void OnResourceUnload(ResourceStation resourceStation);
    public abstract void OnResourceUse(ResourceStation resourceStation);
    public abstract void OnResourceDestroy();
}
