using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Live")]
public class LiveAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Live(controller);
    }

    private void Live(BaseStateController controller)
    {
        // Put quietly sound
        // Fullfil armoured bar to proper section - ScriptableObject with config settings (including max succeess needed for reaching protected state)
    }
}
