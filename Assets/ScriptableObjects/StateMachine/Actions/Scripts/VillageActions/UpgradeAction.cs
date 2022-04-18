using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Upgrade")]
public class UpgradeAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Upgrade(controller);
    }

    private void Upgrade(BaseStateController controller)
    {
        // Increment armour
        // Play Succeed sound
    }
}
