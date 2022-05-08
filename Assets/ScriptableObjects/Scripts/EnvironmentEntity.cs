using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnvironmentEntity")]

public class EnvironmentEntity : ScriptableObject
{
    public new string name;
    public bool resourceProvider;
    public bool terrainModifier;
    [Range(0, 1)] public float spawnChance;
    public Vector3 localScale = Vector3.one;
    public Vector3 localPosition = Vector3.zero;
    public GameObject prefab;
    public Sprite mapSprite;
    public Color placeholderColor;
}
