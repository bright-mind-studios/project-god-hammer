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

    private void Survive(BaseStateController controller)
    {
        // Decrease bar
    }
}
