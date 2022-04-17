using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Test/OrderingGreen")]
public class OrderingGreenAction : Action
{
    public override void Act(BaseStateController controller)
    {
        OrderingGreen((SphereStateController)controller);
    }

    private void OrderingGreen(SphereStateController controller)
    {
        if (controller.stateBoolVariable) return;

        CubeStateController cube = FindObjectOfType<CubeStateController>();
        cube.FromStatePushTransitionToState(pushLaunchTransitions[0].demandState, pushLaunchTransitions[0].pushedState, true);
        controller.stateBoolVariable = false;
        controller.orderingGreen = false;
    }
}
