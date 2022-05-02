using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/DifficultyData")]
public class DifficultyData : ScriptableObject
{
    public int villagesAmount;
    public int armouredSections;
    public int secondsPerSection; // Maybe change on Intensity parameters
    [Range(0, 1)] public float failRateMultiplier;

    public int GetMaxArmourSeconds()
    {
        return secondsPerSection * armouredSections;
    }
}
