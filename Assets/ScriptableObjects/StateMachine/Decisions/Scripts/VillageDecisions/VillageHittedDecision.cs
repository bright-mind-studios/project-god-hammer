using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Decisions/Village/VillageHitted")]
public class VillageHittedDecision : Decision
{
    public override bool Decide(BaseStateController controller)
    {
        return HasBeenAttacked((VillageStateController) controller);
    }

    private bool HasBeenAttacked(VillageStateController controller)
    {
        int waveSeconds = controller.worldController.worldData.difficulty.secondsPerSection * controller.villageData.fortificationLevel;
        return controller.HasTimeElapsed(waveSeconds);
    }
}
