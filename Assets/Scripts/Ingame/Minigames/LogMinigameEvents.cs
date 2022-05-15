using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMinigameEvents : MinigameEvents
{
    public override void OnResourceDestroy()
    {
        Debug.Log("Me voy a generar a otra parte");
    }

    public override void OnResourceUse(ResourceStation resourceStation)
    {
        resourceStation.GenerateTree();
    }

    public override void OnResourceUnload(ResourceStation resourceStation)
    {
        Debug.Log("Vuelve pronto!");
        resourceStation.StopAllCoroutines();
        resourceStation.gameObject.SetActive(false);
    }

    public override void OnResourceLoad(ResourceStation resourceStation)
    {
        Debug.Log("Soy un arbol y me he creado");
        resourceStation.gameObject.SetActive(true);
    }
}
