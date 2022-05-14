using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnvilStation : Station
{
    public WeaponItem weapon;
    private Vector3 weaponLocalScale;

    public bool working = false;
    public AnvilCollider anvilCollider;

    public AnvilHammer hammer;
    
    public float[] strenght_levels = {1, 2, 3};
    public float event_time;

    private void OnEnable() => hammer?.gameObject?.SetActive(true);
    private void OnDisable() => hammer?.gameObject?.SetActive(false);
    public void OnPushWeapon(SelectEnterEventArgs args)
    {
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is WeaponItem m) 
        {
            weapon = m;
            m.GetComponent<Collider>().isTrigger = true;
            weaponLocalScale = m.transform.localScale;
            m.transform.localScale *= 2;
        }
    }

    public void OnPullWeapon(SelectExitEventArgs args)
    {
        weapon = null;
        IXRSelectInteractable ixrs = args.interactableObject;
        if (ixrs is WeaponItem m) 
        {
            m.GetComponent<Collider>().isTrigger = false;
            m.transform.localScale = weaponLocalScale;
        }
        anvilCollider.StopEvent();
    }

    public void OnPressButton()
    {
        if(working || weapon == null) return;
        anvilCollider.StartEvent(event_time);
    }

    public void UpgradeWeapon(int score)
    {
        if(weapon != null)
            weapon.weapon.level = Mathf.Max(weapon.weapon.level, score);
    }

    
}
