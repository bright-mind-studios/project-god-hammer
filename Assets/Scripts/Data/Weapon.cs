using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "project-god-hammer/Weapon", order = 5)]
public class Weapon : Resource
{   
   public enum Type{
       sword,
       shield,
       axe,
       spear
   }

   public Metal metal;
   public Type type;
   public WeaponShape shape;
}
