using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapInteractor : XRSocketInteractor
{
    public GameObject ingotPrefab;
    public Transform spawnPoint;

    [ContextMenu("smelt")]
    public void smelt()
    {
        for (int i = interactablesSelected.Count - 1; i >= 0; i--)
        {
            if (interactablesSelected[i] is MetalItem m) {
                GenerateMetalIngot((Metal) m.resource);
                Destroy(m.gameObject);
            }
        }
    }

    public void GenerateMetalIngot(Metal metal)
    {
        Debug.Log("AAAAA");
        var ingotItem = Instantiate(ingotPrefab, spawnPoint.position, spawnPoint.rotation);
        ingotItem.GetComponent<IngotItem>().SetMetal(metal);
    }


    public void SelectEntered(SelectEnterEventArgs args)
    {

    }

    public void SelectExited(SelectExitEventArgs args)
    {

    }
}
