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
    

    public void OnEnable() 
    {
        for(int i = 0; i < shapeSelectors.Count; i++){
            int shapeTypeIdx = i;
            shapeSelectors[shapeTypeIdx].OnPressButton += ()=> swapShape(shapeTypeIdx);
        }        
    }

    public void OnDisable() 
    {
        for(int i = 0; i < shapeSelectors.Count; i++){
            shapeSelectors[i].OnPressButton -= ()=> swapShape(i);
        }
    }

     public void swapShape(int type)
    {
        currentShape = currentType == type ? (currentShape + 1) % shapesPerType : 0;
        currentType = type;   
        int id = currentType * shapesPerType + currentShape;
        if(id < shapes.Count)     
            mold.setWeaponShape(shapes[id]); 
    }
    
}
