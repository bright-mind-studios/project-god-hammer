using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Death")]
public class DeathAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Death((VillageStateController) controller);
    }

    private void Death(VillageStateController controller)
    {
        if (controller.stateBoolVariable) return;

        Debug.Log("Death");
        // Delete armour bar and change village Sprite to Death one
        controller.armourBar.Disable();
        // Play death sound
        // Inform world to delete this village
        WorldStatus status = new WorldStatus(controller.gameObject, true);
        controller.worldController.FromStatePushTransitionToState(pushLaunchTransitions[0].demandState, pushLaunchTransitions[0].pushedState, false, status);
        controller.stateBoolVariable = true;
    }
}
