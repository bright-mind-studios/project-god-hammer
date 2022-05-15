using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnoppyVillage : MonoBehaviour
{
    [SerializeField] private ArmourBar _minigameBar;
    [SerializeField] private QuestDisplay _questDisplay;
    private ArmourBar _realBar;
    private VillageStateController _controller;
    
    public void SnoppyBarTo(ArmourBar realBar)
    {
        _realBar = realBar;
        _minigameBar.slider.minValue = _realBar.slider.minValue;
        _minigameBar.slider.maxValue = _realBar.slider.maxValue;
    }

    public void SnoppyStateTo(VillageStateController villageController)
    {
        _controller = villageController;
    }

    private void LateUpdate()
    {
        SnoppyBar();
        SnoppyState();
        SnoppyQuest();
    }

    private void SnoppyBar()
    {
        if (_realBar == null) return;

        _minigameBar.slider.value = _realBar.slider.value;
        _minigameBar.fill.color = _realBar.fill.color;
    }

    private void SnoppyState()
    {
        bool requestEnabled = _controller.currentState.name.Equals("Surviving");
        transform.GetChild(2).gameObject.SetActive(requestEnabled);
    }

    private void SnoppyQuest()
    {
        if (_controller.currentQuest == null) return;

        _questDisplay.RenderQuest(_controller.currentQuest);
    }

    public void CheckQuest(SelectEnterEventArgs args)
    {
        if (_controller.currentQuest == null) return;

        WeaponItem weaponAttached = args.interactableObject.transform.gameObject.GetComponent<WeaponItem>();
        bool questCompleted = weaponAttached.weapon.shape.Equals(_controller.currentQuest.weapon.shape) && 
            weaponAttached.weapon.element.Equals(_controller.currentQuest.weapon.element) &&
            weaponAttached.weapon.level >= _controller.currentQuest.weapon.level;
        if (questCompleted)
        {
            PushTransition transition = _controller.currentState.actions[0].pushLaunchTransitions[0];
            _controller.FromStatePushTransitionToState(transition.demandState, transition.pushedState, false);
            Destroy(weaponAttached.gameObject);
        }
    }
}
