using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Protect")]
public class ProtectAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Protect(controller);
    }

    private void Protect(BaseStateController controller)
    {
        // Change bar to protected
        // Inform world
        // Play sound of village's victory
    }
}
