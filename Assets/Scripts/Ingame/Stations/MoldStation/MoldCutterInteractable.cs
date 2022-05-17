using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(LineRenderer))]
public class MoldCutterInteractable : GrabInteractable
{
    private LineRenderer rayRenderer;
    [SerializeField] private Mold mold;
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private float maxdistance = 4f;
    [SerializeField] InputActionReference actionTriggerRight;
    [SerializeField] InputActionReference actionTriggerLeft;
    [SerializeField] Transform marker;

    private void Start() 
    {
        InitBeam();
    }

    protected override void OnEnable() 
    {
        base.OnEnable();
        actionTriggerRight.action.started += TriggerStart;
        actionTriggerRight.action.canceled += TriggerEnd;
        actionTriggerLeft.action.started += TriggerStart;
        actionTriggerLeft.action.canceled += TriggerEnd;    
    }

    protected override void OnDisable() {
        base.OnEnable();
        actionTriggerRight.action.started -= TriggerStart;
        actionTriggerRight.action.canceled -= TriggerEnd;
        actionTriggerLeft.action.started -= TriggerStart;
        actionTriggerLeft.action.canceled -= TriggerEnd;    
    }

    public void TriggerStart(CallbackContext _)
    {
        Debug.Log("AAA");
        base.OnTriggerStart();
        rayRenderer.enabled = true;
    }

    public void TriggerEnd(CallbackContext _)
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
