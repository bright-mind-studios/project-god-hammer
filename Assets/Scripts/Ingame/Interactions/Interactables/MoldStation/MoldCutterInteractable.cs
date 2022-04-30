using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class MoldCutterInteractable : GrabInteractable
{
    private LineRenderer rayRenderer;
    [SerializeField] private Mold mold;
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private float maxdistance = 4f;

    private void Start() 
    {
        InitBeam();
    }

    public override void OnTriggerStart()
    {
        base.OnTriggerStart();
        rayRenderer.enabled = true;
    }

    public override void OnTriggerEnd()
    {
        base.OnTriggerEnd();
        rayRenderer.enabled = false;
        mold.OnCutterStop();
    }

    private void Update() {
        if(rayRenderer.enabled)
        {           
            if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxdistance, raycastMask)){
                rayRenderer.SetPosition(1, transform.TransformPoint(hit.point));
                mold.OnCutterHit(hit.point);
            }
            else{
                rayRenderer.SetPosition(1, Vector3.down * maxdistance);
            }
        }
    }

    private void InitBeam()
    {
        rayRenderer = GetComponent<LineRenderer>();
        rayRenderer.enabled = false;
        rayRenderer.useWorldSpace = false;
        rayRenderer.positionCount = 2;
        rayRenderer.SetPosition(0, Vector3.down * maxdistance);
    }
}
