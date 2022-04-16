using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(BaseStateController controller)
    {
        ExecuteActions(controller);
        CheckForTransitions(controller);
    }

    private void ExecuteActions(BaseStateController controller)
    {
        foreach (var action in actions)
        {
            action.Act(controller);
        }
    }

    private void CheckForTransitions(BaseStateController controller)
    {
        foreach (var transition in transitions)
        {
            bool decision = transition.decision.Decide(controller);

            if (decision)
            {
                controller.TransitionToState(transition.trueState);
            } else
            {
                controller.TransitionToState(transition.falseState);
            }
        }
    }
}
