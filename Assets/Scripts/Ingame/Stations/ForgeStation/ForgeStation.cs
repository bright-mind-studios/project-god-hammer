using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Tweening;

public class ForgeStation : Station
{
    public bool working = false;
    public int fuel = 0;
    public int MAX_FUEL = 10;
    public float animation_time = 0.5f;
    public float smelting_time = 3f;
    public GameObject ingotPrefab;
    public List<MetalItem> metalItems;
    public Transform gate;

    private void Awake() {
        metalItems = new List<MetalItem>();
    }

    [ContextMenu("Smelt")]
    public void Fire()
    {
        if(fuel > 0 && !working)
            StartCoroutine(SmeltCorroutine());
    }

    public void OnDropFuel(SelectEnterEventArgs args)
    {
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is FireWoodItem f)
        {
            Destroy(f.gameObject);
            fuel = Mathf.Min(fuel + 1, MAX_FUEL);
        }
    }

    public void OnPushMetalOre(SelectEnterEventArgs args)
    {
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is MetalItem m)
        {
            metalItems.Add(m);
        }
    }

    public void OnPullMetalOre(SelectExitEventArgs args)
    {
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is MetalItem m)
        {
            metalItems.Remove(m);
        }
    }

    private IEnumerator SmeltCorroutine()
    {
        working = true;
        fuel -= 1;
        var current_time = 0f;
        var delta = 1f / animation_time;
        while(gate.localScale.y != 1f)
        {
            current_time += Time.deltaTime;
            var t = delta * current_time;
            gate.localScale = new Vector3(1, TweenUtils.SmoothLerp(0.1f, 1f, t), 1);
            yield return null;
        }
        yield return new WaitForSeconds(smelting_time);
        Smelt();
        current_time = 0f;
        while(gate.localScale.y != .1f)
        {
            current_time += Time.deltaTime;
            var t = delta * current_time;
            gate.localScale = new Vector3(1, TweenUtils.SmoothLerp(1f, 0.1f, t), 1);
            yield return null;
        }
        working = false;
    }

    public void Smelt()
    {
        for (int i = metalItems.Count - 1; i >= 0; i--)
        {
            Metal metal = (Metal) metalItems[i].resource;
            var pos = metalItems[i].transform.position;
            var rot = metalItems[i].transform.rotation;
            Destroy(metalItems[i].gameObject); 
            var ingot = Instantiate(ingotPrefab, pos, rot);
            ingot.GetComponent<IngotItem>().SetMetal(metal);                       
        }

    }

    
}
