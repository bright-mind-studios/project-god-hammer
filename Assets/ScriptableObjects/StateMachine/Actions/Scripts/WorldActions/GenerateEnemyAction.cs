using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/GenerateEnemy")]
public class GenerateEnemyAction : Action
{
    public override void Act(BaseStateController controller)
    {
        GenerateEnemy((WorldStateController) controller);
    }

    private void GenerateEnemy(WorldStateController controller)
    {
        if (controller.stateBoolVariable) return;

        controller.stateTimeElapsed = 0;
        // Select some villages and push them to make a request
        int numberOfAttacks = Random.Range(1, controller.VillagesCount/2 + 2);
        int villageIdx;
        int tries = 0;
        while (numberOfAttacks > 0 && tries < controller.VillagesCount * 2)
        {
            villageIdx = Random.Range(0, controller.VillagesCount);
            VillageStateController village = controller.GetVillage(villageIdx);
            if (village.currentState.name == "Living")
            {
                numberOfAttacks--;
                village.FromStatePushTransitionToState(pushLaunchTransitions[0].demandState, pushLaunchTransitions[0].pushedState, true);
                controller.worldData.activeRequests++;
            }
            else
            {
                tries++;
            }
        }
        //Increase activeRequests
        controller.stateBoolVariable = true;
    }
}
