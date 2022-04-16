using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "VillageStats")]
public class VillageStats : ScriptableObject
{
    public int lifes;
    public int fortificationLevel;
    public Vector2 mapPosition;
}

