using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Survive")]
public class SurviveAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Survive((VillageStateController) controller);
    }

    private void Survive(VillageStateController controller)
    {
        // Decrease bar - Calling Reduce from ArmourBar passing as argument time.deltaTime
        controller.armourBar.ReduceArmourBySeconds(Time.deltaTime);
    }
}
