using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShapeSelectorInteractable : TouchInteractable
{   

    private Vector3 starPos; 
    [SerializeField] private Transform target;
    [SerializeField] private float offset;
    [SerializeField] private MoldStation station;
    [SerializeField] private int type;

    private void Start() {
        starPos = transform.position;
    }
    public override void OnHoverEnter(HoverEnterEventArgs args){
        target.position = starPos + Vector3.down * offset;
        station.swapShape(type);
    }

    public override void OnHoverExit(HoverExitEventArgs args){
       target.position = starPos;
    }

    public override void OnTriggerStart(){
        base.OnTriggerStart();
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
    
}
