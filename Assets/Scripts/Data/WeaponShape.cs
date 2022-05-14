using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponShape", menuName = "project-god-hammer/WeaponShape", order = 4)]
public class WeaponShape : ScriptableObject
{
    public Vector3[] points;
    public GameObject moldPrefab;

    public GameObject weaponPrefab;

    [ContextMenu("RenderShape")]
    public void RenderShape()
    {
        for (int i = 0; i < points.Length; i++)
        {
            var a = points[i];
            var b = points[(i + 1) % points.Length];
            Debug.DrawLine(a, b, Color.white, 5f);
        }
    }


}
