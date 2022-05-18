using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Automatic")]
public class Auto : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return Automatic(controller);
    }

    private bool Automatic(BaseStateController controller)
    {
        return true;
    }
}
