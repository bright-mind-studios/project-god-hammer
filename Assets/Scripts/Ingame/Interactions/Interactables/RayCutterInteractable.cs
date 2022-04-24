using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayCutterInteractable : GrabInteractable
{
    [SerializeField] private float maxDistance = 100f;
    private LineRenderer rayRenderer;

    private void Start() {
        rayRenderer = GetComponent<LineRenderer>();
        rayRenderer.enabled = false;
        rayRenderer.useWorldSpace = false;
        rayRenderer.positionCount = 2;
        rayRenderer.SetPosition(0, Vector3.down);
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
    }

    private void Update() {
        if(rayRenderer.enabled)
        {
            if(Physics.Raycast(transform.position + Vector3.down * 2, Vector3.down, out RaycastHit hit, maxDistance)){
                rayRenderer.SetPosition(1, transform.TransformPoint(hit.point));
            }
            else{
                rayRenderer.SetPosition(1, Vector3.down * maxDistance);
            }
        }
    }
}
