using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StateMachines/Actions/Village/Concern")]
public class ConcernAction : Action
{
    public override void Act(BaseStateController controller)
    {
        Concern((VillageStateController) controller);
    }

    private void Concern(VillageStateController controller)
    {
        AudioSource audioSource = controller.GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.volume = 1;
        audioSource.clip = controller.audioClips[2];
        audioSource.Play();
        audioSource.loop = false;

        Debug.Log("Generating Weapon");
        controller.currentQuest = FindObjectOfType<QuestGenerator>().GenerateQuest(controller.villageData.fortificationLevel);
        
        
    }
}
