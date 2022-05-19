using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Live")]
public class LiveAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Live((VillageStateController) controller);
    }

    private void Live(VillageStateController controller)
    {
        if (controller.stateBoolVariable) return;

        AudioSource audioSource = controller.GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.volume = 1;
        audioSource.clip = controller.audioClips[1];
        audioSource.loop = true;
        audioSource.Play();
        
        controller.armourBar.SetSecondsOfArmour(controller.worldController.worldData.difficulty.secondsPerSection * controller.villageData.fortificationLevel);
        controller.stateBoolVariable = true;
    }
}
