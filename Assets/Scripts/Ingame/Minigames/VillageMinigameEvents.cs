using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageMinigameEvents : MinigameEvents
{
    public override void OnResourceDestroy(MinigameManager minigameManager)
    {
        Debug.Log("Me voy a generar a otra parte");
    }

    public override void OnResourceUse(ResourceStation resourceStation)
    {
        
    }

    public override void OnResourceUnload(ResourceStation resourceStation)
    {
        Debug.Log("Vuelve pronto!");
    }

    public override void OnResourceLoad(ResourceStation resourceStation, MinigameManager minigameManager)
    {
        Debug.Log("Soy una aldea y me he creado");
        SnoppyVillage snoppy = minigameManager.GetResourceMinigame().GetComponent<SnoppyVillage>();
        ArmourBar armourBar = minigameManager.GetResourceInstance().transform.GetChild(0).GetChild(0).GetComponent<ArmourBar>();
        snoppy.SnoppyBarTo(armourBar);
        snoppy.SnoppyStateTo(minigameManager.GetResourceInstance().GetComponent<VillageStateController>());
    }
}
