using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/World/SavedWorld")]
public class SavedWorldDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return SavedWorld(controller);
    }

    private bool SavedWorld(BaseStateController controller)
    {
        return false;
    }
}
