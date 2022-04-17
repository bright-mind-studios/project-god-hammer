using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Test/OnBPressed")]
public class OnBPressedDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return OnBPressed((SphereStateController) controller);
    }

    private bool OnBPressed(SphereStateController controller)
    {
        return controller.orderingGreen;
    }
}
