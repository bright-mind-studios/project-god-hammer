using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoldShapeSelector : MonoBehaviour
{
    [SerializeField] Mold mold;
    [SerializeField] List<WeaponShape> shapes;
    [SerializeField] List<ButtonInteractable> shapeSelectors;
    [SerializeField] int shapesPerType = 2;
    [SerializeField] int currentType;
    [SerializeField] int currentShape;    
}
