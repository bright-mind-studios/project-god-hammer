using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InputZone : MonoBehaviour
{    
    public event Func<Resource, bool> OnTakeResource; 
    public bool actived = true;
    private void OnTriggerEnter(Collider other) {   

        if(!actived) return;

        ResourceItem item = other.gameObject.GetComponent<ResourceItem>();
        if(item != null)
        {
            bool? validResource = OnTakeResource?.Invoke(item.resource);
            if(validResource != null && (bool)validResource) Destroy(other.gameObject);
        }
    }



    public void SetActived(bool actived) => this.actived = actived;
}
