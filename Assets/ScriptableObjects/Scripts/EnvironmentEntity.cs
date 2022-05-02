using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnvironmentEntity")]

public class EnvironmentEntity : ScriptableObject
{
    public new string name;
    public GameObject prefab;
    [Range(0, 1)] public float spawnChance;
}
