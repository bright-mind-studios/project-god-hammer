using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Test/Blue")]
public class BlueAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Blue(controller);
    }

    private void Blue(BaseStateController controller)
    {
        if (controller.stateBoolVariable) return;
        Debug.Log("Turning blue");
        controller.GetComponent<Renderer>().material.color = Color.blue;
        controller.stateBoolVariable = true;
    }
}
