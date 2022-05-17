using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/World/Win")]
public class WinAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Win((WorldStateController)controller);
    }

    private void Win(WorldStateController controller)
    {
        if (controller.stateBoolVariable) return;

        Debug.Log("VICTORY: "+controller.worldData.aliveVillages+" VILLAGE/S OF "+controller.worldData.difficulty.villagesAmount+" SURVIVED");

        GameManager.Instance.SetResults(true, controller.worldData.aliveVillages, controller.worldData.difficulty.villagesAmount);
        GameManager.Instance.LoadResults();

        controller.stateBoolVariable = true;
    }
}
