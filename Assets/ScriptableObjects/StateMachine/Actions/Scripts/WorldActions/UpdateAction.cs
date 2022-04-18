using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/Update")]
public class UpdateAction : Action
{
    public override void Act(BaseStateController controller)
    {
        UpdateStatus(controller);
    }

    private void UpdateStatus(BaseStateController controller)
    {

    }
}
