using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Test/Red")]
public class RedAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Red(controller);
    }

    private void Red(BaseStateController controller)
    {
        if (controller.stateBoolVariable) return;
        Debug.Log("Turning red");
        controller.GetComponent<Renderer>().material.color = Color.red;
        controller.stateBoolVariable = true;
    }
}
