using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Survive")]
public class SurviveAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Survive((VillageStateController) controller);
    }

    private void Survive(VillageStateController controller)
    {
        if (!controller.stateBoolVariable)
        {
            AudioSource audioSource = controller.GetComponent<AudioSource>();

            if (!audioSource.isPlaying)
            {
                audioSource.clip = controller.audioClips[0];
                audioSource.volume = 0.5f;
                audioSource.Play();
                audioSource.loop = true;
                controller.stateBoolVariable = true;
            }
        }
        
        
        // Decrease bar - Calling Reduce from ArmourBar passing as argument time.deltaTime
        controller.armourBar.ReduceArmourBySeconds(Time.deltaTime);
    }
}
