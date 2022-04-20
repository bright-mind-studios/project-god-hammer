using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/Update")]
public class UpdateAction : Action
{
    public override void Act(BaseStateController controller)
    {
        UpdateStatus((WorldStateController) controller);
    }

    private void UpdateStatus(WorldStateController controller)
    {
        if (controller.stateBoolVariable) return;

        WorldStatus status = (WorldStatus) controller.activeStatus;

        if (status != null)
        {
            controller.DeleteVillage(status.Id.GetComponent<VillageStateController>());

            if (status.DeathVillage) controller.worldData.aliveVillages--;
        }
        else
        {
            controller.worldData.activeRequests--;
        }

        controller.stateBoolVariable = true;
    }
}
