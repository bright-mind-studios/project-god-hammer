using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Live")]
public class LiveAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Living(controller);
    }

    private void Living(BaseStateController controller)
    {
        // WorldStateController world = (WorldStateController) controller;
        // BaseStateController d = world.GetVillage();
        // d.FromStatePushTransitionToState(pushLaunchTransitions[0].demandState, pushLaunchTransitions[0].pushedState, true);
        // Put quietSound for the controller.audioSource - With boolean from controller just 1 time
    }
}
