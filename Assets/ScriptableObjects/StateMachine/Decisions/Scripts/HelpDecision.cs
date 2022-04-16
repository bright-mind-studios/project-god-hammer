using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Village/Help")]
public class HelpDecision : Decision
{
    // Must be a push decision. So just wait to see how create them. 
    public override bool Decide(BaseStateController controller)
    {
        return Help();
    }

    private bool Help()
    {
        return true;
    }
}
