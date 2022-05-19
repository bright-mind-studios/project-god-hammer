using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CauldronStation : Station
{
    [SerializeField] private IngotItem primarymetal, secondaryMetal;
    [SerializeField] public List<Alloy> allAlloys;
    [SerializeField] private CalderoManager _calderoManager;
    public GameObject ingotPrefab;

    public Transform spawnPoint;


    public void OnPushPrimaryMetal(SelectEnterEventArgs args)
    {
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is IngotItem i) 
        {
            if (i.resource is Metal m) primarymetal = i;
        }
    }
    
    public void OnPushSecondaryMetal(SelectEnterEventArgs args)
    {
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is IngotItem i) 
        {
            if (i.resource is Metal m) secondaryMetal = i;
        }
    }

    public void OnPullPrimaryMetal(SelectExitEventArgs args)
    {
        primarymetal = null;
    }

    public void OnPullSecondaryMetal(SelectExitEventArgs args)
    {
        secondaryMetal = null;
    }

    public void OnPressButton()
    {
        _calderoManager.StartCauldronMinigame();
    }
    
    public void OnWin()
    {
        if(primarymetal == null || secondaryMetal == null) return;
        Metal m1 = primarymetal.resource as Metal;
        Metal m2 = secondaryMetal.resource as Metal;
        Alloy alloy = allAlloys.Find((a) => {
                return a.primaryMetal == m1 && a.secondaryMetal == m2 ||
                       a.primaryMetal == m2 && a.secondaryMetal == m1;
            }
        );

        if(alloy != null)
        {
            Destroy(primarymetal.gameObject);
            Destroy(secondaryMetal.gameObject);
            var ingotItem = Instantiate(ingotPrefab, spawnPoint.position, spawnPoint.rotation);
            ingotItem.GetComponent<IngotItem>().SetMetal(alloy);
        }
    }
}

