using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Village/VillageHitted")]
public class VillageHittedDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return HasBeenAttacked(controller);
    }

    private bool HasBeenAttacked(BaseStateController controller)
    {
        controller.HasTimeElapsed(300); // Think how to define the time to wait
        return false;
    }
}
