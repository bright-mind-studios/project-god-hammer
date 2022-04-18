using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/DifficultyData")]
public class DifficultyData : ScriptableObject
{
    public int armouredSections;
    public int secondsPerSection;
    [Range(0, 1)] public float failRateMultiplier;
}
