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
        // Generate petition calling independent system from controller.GetComponent -> its gameobject. if == null return, else generate petition
    }
}
