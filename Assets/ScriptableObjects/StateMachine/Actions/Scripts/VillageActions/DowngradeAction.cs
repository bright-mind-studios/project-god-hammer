using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Downgrade")]
public class DowngradeAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Downgrade(controller);
    }

    private void Downgrade(BaseStateController controller)
    {
        // Reduce lives
        // Play Hit sound
    }
}
