using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/World/EndOfGame")]
public class EndOfGameDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return EndOfGame(controller);
    }

    private bool EndOfGame(BaseStateController controller)
    {
        return false;
    }
}
