using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Test/OnTouch")]
public class OnTouchDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return IsBeenTouched((CubeStateController) controller);
    }

    private bool IsBeenTouched(CubeStateController controller)
    {
        return controller.isBeenTouched;
    }
}
