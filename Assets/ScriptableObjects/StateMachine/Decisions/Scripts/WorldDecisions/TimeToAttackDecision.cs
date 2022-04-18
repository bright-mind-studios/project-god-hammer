using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/World/TimeToAttack")]
public class TimeToAttackDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return TimeToAttack(controller);
    }

    private bool TimeToAttack(BaseStateController controller)
    {
        return false;
    }
}
