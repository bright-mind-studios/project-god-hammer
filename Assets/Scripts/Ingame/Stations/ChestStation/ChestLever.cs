using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestLever : MonoBehaviour
{
    [SerializeField] private ChestStation chest;
    
    private void OnTriggerEnter(Collider other) 
    {
        ChestLevelTrigger clt = other.gameObject.GetComponent<ChestLevelTrigger>();
        if(clt != null)
            chest.rotate(clt.direction ? 1 : -1);
    }
}
