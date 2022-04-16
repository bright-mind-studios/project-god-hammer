using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Act(BaseStateController controller);
    public PushTransition[] pushLaunchTransitions;
}
