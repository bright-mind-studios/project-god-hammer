using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InputZone : MonoBehaviour
{    
    public event Action<Resource> OnTakeResource; 
    private void OntriggerEnter(Collider other) {
        ResourceItem<Resource> item = other.gameObject.GetComponent<ResourceItem<Resource>>();
        if(item != null)
        {
            OnTakeResource?.Invoke(item.resource);
            Destroy(other.gameObject);
        }
    }
}
