using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/Lose")]
public class LoseAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Lose(controller);
    }

    private void Lose(BaseStateController controller)
    {
        if (controller.stateBoolVariable) return;

        Debug.Log("END GAME: ALL VILLAGE WERE DESTROYED");
        controller.stateBoolVariable = true;
    }
}
