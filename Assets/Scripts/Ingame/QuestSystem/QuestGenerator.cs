using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class QuestGenerator : MonoBehaviour
{
    public WeaponShape[] allWeapons;
    public Element[] allElements;

    public int maxWeaponLevel = 3;
    public int maxElementLevel = 5;

    private void Awake() {
        allWeapons = Resources.FindObjectsOfTypeAll<WeaponShape>();
        List<Element> auxList = Resources.FindObjectsOfTypeAll<Element>().ToList<Element>();
        for (int i = auxList.Count - 1; i >= 0; i--)
        {
            if(auxList[i] is Metal m && m.tier == Metal.Tier.special) 
                auxList.RemoveAt(i);
        }
        allElements = auxList.ToArray();
    }

    public Quest GenerateQuest(int level = 1)
    {
        Quest quest = new Quest();
        Weapon weapon = new Weapon();
        weapon.shape = allWeapons.OrderBy(x => UnityEngine.Random.value).First();
        weapon.element = Array.FindAll<Element>(allElements, 
                    (element) => element.GetLevel() >= Mathf.Min(UnityEngine.Random.Range(1, level + 1), maxElementLevel))
                    .OrderBy(x => UnityEngine.Random.value).First();
        weapon.level = UnityEngine.Random.Range(1, maxWeaponLevel + 1);
        quest.weapon = weapon;
        return quest;
    }

    [ContextMenu("Test")]
    public void TestQuestGenerator()
    {
        int level = 5;
        for (int i = 0; i < 100; i++)
        {
            Quest quest = GenerateQuest(level);
            Debug.Log("QUEST (Lvl " + level + "): " + quest.weapon.shape.name + " - " + quest.weapon.element.name);
        }        
    }

    [ContextMenu("foo")]
    public void foo()
    {
        FindObjectOfType<QuestDisplay>().RenderQuest(GenerateQuest(5));
    }

    
    
}
