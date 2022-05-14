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
    [SerializeField] Transform marker;

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
        //mold.OnCutterStop();
    }

    private void Update() {
        if(rayRenderer.enabled)
        {           
            if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxdistance, raycastMask)){    
                mold.OnCutterHit(hit.point);
                Vector3 collisionPoint = transform.InverseTransformPoint(hit.point);
                SetMarkerPosition(collisionPoint);
            }
            else{
                SetMarkerDefaultPosition();
            }
        }
    }

    private void InitBeam()
    {
        rayRenderer = GetComponent<LineRenderer>();
        rayRenderer.enabled = false;
        rayRenderer.useWorldSpace = false;
        rayRenderer.positionCount = 2;
        rayRenderer.SetPosition(1, Vector3.down * maxdistance);
    }

    private void SetMarkerDefaultPosition() => SetMarkerPosition(Vector3.down * maxdistance);

    private void SetMarkerPosition(Vector3 localPosition)
    {
        rayRenderer.SetPosition(1, localPosition);
        marker.localPosition = localPosition;
    }
}
