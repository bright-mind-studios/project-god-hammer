using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Village/DeathSentence")]
public class DeathSentenceDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return IsVillageDeath((VillageStateController) controller);
    }

    private bool IsVillageDeath(VillageStateController controller)
    {
        return controller.villageData.lives <= 0;
    }
}
