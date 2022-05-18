using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/Wait")]
public class WaitAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Wait(controller);
    }

    private void Wait(BaseStateController controller)
    {
        //Not use assigned
    }
}
