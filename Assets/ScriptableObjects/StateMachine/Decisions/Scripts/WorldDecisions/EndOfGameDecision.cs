using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/World/EndOfGame")]
public class EndOfGameDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return EndOfGame((WorldStateController) controller);
    }

    private bool EndOfGame(WorldStateController controller)
    {
        return controller.VillagesCount <= 0;
    }
}
