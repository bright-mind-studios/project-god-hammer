using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Mold : MonoBehaviour
{
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private MoldGuide guide;

    private WeaponShape currentShape;
    public bool completed;

    public event Action<bool> OnChangeState; 

    public int lastPointIdx, currentPointIdx;

    private void Start() 
    {
        completed = false;
        OnChangeState?.Invoke(completed);
    }

    private void ResetMold()
    {
        completed = false;
        OnChangeState?.Invoke(completed);
        lastPointIdx = currentPointIdx = 0;
        guide.MoveTarget(currentShape.points[currentPointIdx]);
    }

    public void setWeaponShape(WeaponShape shape){
        currentShape = shape;
        guide.Trigger(true);
        ResetMold();
        guide.RenderGuideLine(currentShape.points.ToArray());
    }

    public void OnCutterHit(Vector3 collisionPoint)
    {
        if(completed || currentShape == null) return;

        collisionPoint = transform.InverseTransformPoint(collisionPoint);
        if (Vector2.Distance(collisionPoint, currentShape.points[currentPointIdx]) < threshold)
        {
            UpdatePoint();
        }
        else 
        {
            Vector3 closestPointOnLine = GetClosestPointOnFiniteLine(collisionPoint, currentShape.points[lastPointIdx], currentShape.points[currentPointIdx]);
            if(Vector2.Distance(collisionPoint, closestPointOnLine) > threshold)
            {
                Debug.Log(collisionPoint + " / " + currentShape.points[lastPointIdx] +" / " + currentShape.points[currentPointIdx]);
                ResetMold();
            }
        }
    }

    public void OnCutterStop()
    {
        if(!completed) ResetMold();
    }

    private void UpdatePoint()
    {
        lastPointIdx = currentPointIdx;
        currentPointIdx += 1;
        if(currentPointIdx >= currentShape.points.Count)
        {
            completed = true;
            OnChangeState?.Invoke(completed);
            guide.Trigger(false);
        }
        else{
            guide.MoveTarget(currentShape.points[currentPointIdx]);
        }

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
