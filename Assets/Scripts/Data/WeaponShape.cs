using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponShape", menuName = "project-god-hammer/WeaponShape", order = 4)]
public class WeaponShape : ScriptableObject
{
    public List<Vector2> points;
}
