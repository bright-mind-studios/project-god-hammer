using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/World/TimeToAttack")]
public class TimeToAttackDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return TimeToAttack((WorldStateController) controller);
    }

    private bool TimeToAttack(WorldStateController controller)
    {
        return controller.HasTimeElapsed(controller.worldData.intensity.secondsBetweenAttacks) || controller.worldData.activeRequests == 0;
    }
}
