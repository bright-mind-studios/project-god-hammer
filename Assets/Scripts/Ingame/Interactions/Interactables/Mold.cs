using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mold : MonoBehaviour
{
    [SerializeField] private LineRenderer templateShapeRenderer;    // Guía de la forma del molde
    [SerializeField] private LineRenderer currentShapeRenderer;     // Linea trazada por el jugador
    [SerializeField] private Transform targetPoint;                 // Punto actual

    [SerializeField] private float beamThreshold = 0.2f;

    private bool active, Interaction;

    public void renderTemplateShape(Vector3[] positions){
        templateShapeRenderer.positionCount = positions.Length;
        templateShapeRenderer.SetPositions(positions);
        SetTargetPointPosition(templateShapeRenderer.GetPosition(0));
    }

    private void SetTargetPointPosition(Vector3 relativePos)
    {
        Vector3 worldPos = templateShapeRenderer.transform.TransformPoint(relativePos);
        targetPoint.position = worldPos;
    }

    // Animación que reinicia el molde
    private void RenewMold()
    {

    }

    public void checkBeamCollision(Vector3 collisionPoint)
    {
        // if (Vector3.Distance(collisionPoint, targetPoint.position) < beamThreshold)
        // {
        //     targetPoint.position = 
        // }

    }

    private static Vector3 GetClosestPointOnFiniteLine(Vector3 point, Vector3 line_start, Vector3 line_end)
    {
        Vector3 line_direction = line_end - line_start;
        float line_length = line_direction.magnitude;
        line_direction.Normalize();
        float project_length = Mathf.Clamp(Vector3.Dot(point - line_start, line_direction), 0f, line_length);
        return line_start + line_direction * project_length;
    }
}
