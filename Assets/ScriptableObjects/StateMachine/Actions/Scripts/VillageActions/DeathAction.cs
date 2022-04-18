using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Death")]
public class DeathAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Death(controller);
    }

    private void Death(BaseStateController controller)
    {
        // Change armoured bar to broken
        // Play death sound
        // Inform world to delete this village
    }
}
