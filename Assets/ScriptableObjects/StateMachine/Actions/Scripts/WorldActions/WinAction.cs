using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/Win")]
public class WinAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Win(controller);
    }

    private void Win(BaseStateController controller)
    {

    }
}
