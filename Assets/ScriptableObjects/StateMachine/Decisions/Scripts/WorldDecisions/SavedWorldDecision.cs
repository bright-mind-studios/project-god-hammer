using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/World/SavedWorld")]
public class SavedWorldDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return SavedWorld((WorldStateController) controller);
    }

    private bool SavedWorld(WorldStateController controller)
    {
        return controller.worldData.aliveVillages > 0;
    }
}
