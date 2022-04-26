using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InputZone : MonoBehaviour
{    
    public event Action<Resource> OnTakeResource; 
    private void OnTriggerEnter(Collider other) {        
        ResourceItem item = other.gameObject.GetComponent<ResourceItem>();
        if(item != null)
        {
            Debug.Log("AAA");
            OnTakeResource?.Invoke(item.resource);
            Destroy(other.gameObject);
        }
    }
}
