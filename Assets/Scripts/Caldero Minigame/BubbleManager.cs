using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    private CalderoManager _manager;
    
    private void Start()
    {
        _manager = FindObjectOfType<CalderoManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _manager.AdvanceProgress();
        gameObject.SetActive(false);
    }
}
