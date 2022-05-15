using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] Image spr_base, spr_M1, spr_M2;
    [SerializeField] TextMeshProUGUI name_text, level_text;

    
    public void RenderQuest(Quest quest)
    {
        Active();
        Weapon weapon = quest.weapon;
        spr_base.sprite = weapon.shape.spr_base;
        spr_M1.sprite = weapon.shape.spr_M1;
        spr_M2.sprite = weapon.shape.spr_M2;
        spr_M1.color = weapon.element.GetPrimaryColor();
        spr_M2.color = weapon.element.GetSecondaryColor();
        name_text.text = weapon.shape.name + " de " + weapon.element.name; 
        level_text.text = weapon.level.ToString();
    }

    public void Clear() =>  canvas.SetActive(false);


    public void Active() => canvas.SetActive(true);
}
