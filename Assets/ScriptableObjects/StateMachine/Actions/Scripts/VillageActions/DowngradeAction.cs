using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Downgrade")]
public class DowngradeAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Downgrade((VillageStateController) controller);
    }

    private void Downgrade(VillageStateController controller)
    {
        if (controller.stateBoolVariable) return;

        controller.villageData.lives--;
        controller.worldController.FromStatePushTransitionToState(pushLaunchTransitions[0].demandState, pushLaunchTransitions[0].pushedState, false);
        // Play hit sound
        Debug.Log("Oh, we were attacked");
        controller.stateBoolVariable = true;
    }
}
