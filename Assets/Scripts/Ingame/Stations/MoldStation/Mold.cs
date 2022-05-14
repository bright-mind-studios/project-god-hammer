using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mold : MonoBehaviour
{    
    // 
    [SerializeField] float LINE_THRESHOLD = 0.1f;
    [SerializeField] float POINT_THRESHOLD = 0.05f;
    //
    [SerializeField] MoldStation station;
    [SerializeField] Transform marker;
    [SerializeField] public LineRenderer lineRenderer;
    [SerializeField] List<WeaponShape> shapes;
    public int currentShapeIdx = 0;
    private int currentPointIdx;

    // Properties

    private Vector3[] CurrentShape => shapes[currentShapeIdx].points;
    private Vector3 CurrentPoint => CurrentShape[currentPointIdx];
    private Vector3 LastPoint => CurrentShape[Mathf.Max(currentPointIdx - 1, 0)];
    
    private void OnEnable() 
    {
        lineRenderer.SetPositions(CurrentShape);
        ResetShape();
    }

    public void SwapShape()
    {
        currentShapeIdx = (currentShapeIdx + 1) % shapes.Count;
        lineRenderer.SetPositions(CurrentShape);
        UpdateMarkerPosition();
    }

    private void ResetShape()
    {
        currentPointIdx = 0;
        UpdateMarkerPosition();
    }
    // Evento de colision
    public void OnCutterHit(Vector3 collisionPoint)
    {
        Vector2 localCollisionPoint = transform.InverseTransformPoint(collisionPoint);
        if (Vector2.Distance(localCollisionPoint, CurrentPoint) < POINT_THRESHOLD)
        {
            CompletePoint();         
        }
        else 
        {
            Vector3 closestPointOnLine = GetClosestPointOnFiniteLine(localCollisionPoint, LastPoint, CurrentPoint);
            if(Vector2.Distance(localCollisionPoint, closestPointOnLine) > LINE_THRESHOLD)
            {               
                ResetShape();
            }
        }
    }

    private void CompletePoint()
    {
        if (currentPointIdx == CurrentShape.Length - 1)
        {
            // Minijuego completado
            station.CompleteShape(shapes[currentShapeIdx]);
        }
        else
        {
            currentPointIdx += 1;
            UpdateMarkerPosition();
        }            
    }

    private void UpdateMarkerPosition()
    {
        marker.localPosition = CurrentPoint;
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
