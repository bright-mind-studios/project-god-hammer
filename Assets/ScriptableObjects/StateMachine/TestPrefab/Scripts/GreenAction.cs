using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Test/Green")]
public class GreenAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Green(controller);
    }

    private void Green(BaseStateController controller)
    {
        if (controller.stateBoolVariable) return;
        Debug.Log("Turning green");
        controller.GetComponent<Renderer>().material.color = Color.green;
        controller.stateBoolVariable = true;
    }
}
