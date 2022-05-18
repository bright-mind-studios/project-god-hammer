using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Live")]
public class LiveAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Live((VillageStateController) controller);
    }

    private void Live(VillageStateController controller)
    {
        if (controller.stateBoolVariable) return;

        // Put quietly sound
        controller.armourBar.SetSecondsOfArmour(controller.worldController.worldData.difficulty.secondsPerSection * controller.villageData.fortificationLevel);
        controller.stateBoolVariable = true;
    }
}
