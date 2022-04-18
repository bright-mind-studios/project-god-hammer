using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/GenerateEnemy")]
public class GenerateEnemyAction : Action
{
    public override void Act(BaseStateController controller)
    {
        GenerateEnemy(controller);
    }

    private void GenerateEnemy(BaseStateController controller)
    {

    }
}
