using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/EnvironmentEntity")]

public class EnvironmentEntity : ScriptableObject
{
    public new string name;
    public bool resourceProvider;
    public bool requireResourceStation;
    public bool terrainModifier;
    [Range(0, 1)] public float spawnChance;
    public Vector3 localScale = Vector3.one;
    public Vector3 localPosition = Vector3.zero;
    public GameObject prefab;
    public GameObject minigamePrefab = null;
    public MinigameEvents minigameEvents;
    public int resourceUses = -1;
    public Sprite mapSprite;
}
