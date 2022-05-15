using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDisplay : MonoBehaviour
{
    [SerializeField] SpriteRenderer spr_base, spr_M1, spr_M2;
    [SerializeField] Text name_text, level_text;

    
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

    public void Clear()
    {
        spr_base.gameObject.SetActive(false);
        name_text.gameObject.SetActive(false);
        level_text.gameObject.SetActive(false);
    }

    public void Active()
    {
        spr_base.gameObject.SetActive(true);
        name_text.gameObject.SetActive(true);
        level_text.gameObject.SetActive(true);
    }
}
