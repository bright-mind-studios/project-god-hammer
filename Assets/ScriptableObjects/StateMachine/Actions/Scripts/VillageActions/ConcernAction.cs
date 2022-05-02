using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Concern")]
public class ConcernAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Concern(controller);
    }

    private void Concern(BaseStateController controller)
    {
        // Make a call to world petition generating system
        // Send the petition generated to world list
        // Generate trigger for weapon
        // Change music to attack state
        Debug.Log("Generating Weapon");
    }
}
