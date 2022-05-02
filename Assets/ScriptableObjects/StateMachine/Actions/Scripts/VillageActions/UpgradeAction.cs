using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Upgrade")]
public class UpgradeAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Upgrade((VillageStateController) controller);
    }

    private void Upgrade(VillageStateController controller)
    {
        if (controller.stateBoolVariable) return;
        // Increment armour
        controller.villageData.fortificationLevel++;
        controller.worldController.FromStatePushTransitionToState(pushLaunchTransitions[0].demandState, pushLaunchTransitions[0].pushedState, false);
        // Play Succeed sound
        controller.stateBoolVariable = true;
    }
}
