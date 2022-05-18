using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Protect")]
public class ProtectAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Protect((VillageStateController) controller);
    }

    private void Protect(VillageStateController controller)
    {
        if (controller.stateBoolVariable) return;

        controller.armourBar.ActivateArmour();
        WorldStatus status = new WorldStatus(controller.gameObject, false);
        controller.worldController.FromStatePushTransitionToState(pushLaunchTransitions[0].demandState, pushLaunchTransitions[0].pushedState, false, status);
        // Change bar to protected
        // Inform world
        // Play sound of village's victory
        controller.stateBoolVariable = true;
    }
}
