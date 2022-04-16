using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Survive")]
public class SurviveAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Survive(controller);
    }

    public void Survive(BaseStateController controller)
    {
        if (controller.HasTimeElapsed(300)) // 300 must be replaced by the world controller get mission time call
        {
            //Lose 1 life
        }
    }
}
