using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Village/ArmouredVillage")]
public class ArmouredVillageDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return IsVillageArmoured(controller);
    }

    private bool IsVillageArmoured(BaseStateController controller)
    {
        return false;
    }
}
