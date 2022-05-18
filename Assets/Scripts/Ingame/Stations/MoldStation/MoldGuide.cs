using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldGuide : MonoBehaviour
{

    [SerializeField] private LineRenderer guideLineRenderer;    // Guía de la forma del molde
    [SerializeField] private LineRenderer cutLineRenderer;     // Linea trazada por el jugador
    [SerializeField] private Transform target;                 // Punto actual

    public void RenderGuideLine(Vector3[] positions){

        guideLineRenderer.positionCount = positions.Length;
        guideLineRenderer.SetPositions(positions);
        SetTargetPointPosition(guideLineRenderer.GetPosition(0));        
    }

    private void Awake() => Trigger(false);

    private void SetTargetPointPosition(Vector3 relativePos)
    {
        Vector3 worldPos = guideLineRenderer.transform.TransformPoint(relativePos);
        target.position = worldPos;
    }

    public void MoveTarget(Vector3 pos)
    {
        target.position = transform.TransformPoint(pos) + Vector3.up * 0.2f;
    }

    public void Trigger(bool active){
        guideLineRenderer.gameObject.SetActive(active);
        cutLineRenderer.gameObject.SetActive(active);
        target.gameObject.SetActive(active);
    }
}
