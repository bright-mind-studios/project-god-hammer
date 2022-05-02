using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Village/ArmouredVillage")]
public class ArmouredVillageDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return IsVillageArmoured((VillageStateController) controller);
    }

    private bool IsVillageArmoured(VillageStateController controller)
    {
        return controller.villageData.fortificationLevel > controller.worldController.worldData.difficulty.armouredSections;
    }
}
