using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayCutterInteractable : GrabInteractable
{
    private LineRenderer rayRenderer;
    private LayerMask raycastMask;
    [SerializeField] private float maxdistance = 0.4f;
    [SerializeField] Mold mold;

    private void Start() {
        rayRenderer = GetComponent<LineRenderer>();
        rayRenderer.enabled = false;
        rayRenderer.useWorldSpace = false;
        rayRenderer.positionCount = 2;
        rayRenderer.SetPosition(0, Vector3.down);
        raycastMask.value = mold.gameObject.layer;
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
            //Debug.Log("AAAAAAAAA");
            
            if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxdistance, raycastMask)){
                rayRenderer.SetPosition(1, transform.TransformPoint(hit.point));
                Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.red, 1.0f);
                Debug.Log(hit.transform.gameObject.name);
            }
            else{
                rayRenderer.SetPosition(1, Vector3.down);
            }
        }
    }

    private void InitBeam()
    {
        rayRenderer.enabled = false;
        rayRenderer.useWorldSpace = false;
        rayRenderer.positionCount = 2;
        rayRenderer.SetPosition(0, Vector3.down);
    }
}
