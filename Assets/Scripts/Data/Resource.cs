using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "project-god-hammer/Resource", order = 0)]
public class Resource : ScriptableObject
{
    public string itemname;
    public GameObject prefab;
    public Sprite sprite;
}
