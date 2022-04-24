using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.InputSystem.InputAction;

public class InteractionController : MonoBehaviour
{
    [SerializeField] InputActionReference actionGripRight;
    [SerializeField] InputActionReference actionGripLeft;
    [SerializeField] InputActionReference actionTriggerRight;
    [SerializeField] InputActionReference actionTriggerLeft;

    [SerializeField] XRDirectInteractor directInteractorRight;
    [SerializeField] XRDirectInteractor directInteractorLeft;
    [SerializeField] XRRayInteractor rayInteractorRight;
    [SerializeField] XRRayInteractor rayInteractorLeft;
    
    private void OnEnable() {
        actionGripRight.action.started += OnPressRightGrip;
        actionGripRight.action.canceled += OnReleaseRightGrip;
        actionGripLeft.action.started += OnPressLeftGrip;
        actionGripLeft.action.canceled += OnReleaseLeftGrip;
        actionTriggerRight.action.started += OnPressRightTrigger;
        actionTriggerRight.action.canceled += OnReleaseRightTrigger;
        actionTriggerLeft.action.started += OnPressLeftTrigger;
        actionTriggerLeft.action.canceled += OnReleaseLeftTrigger;
    }

    private void OnDisable() 
    {
        actionGripRight.action.started -= OnPressRightGrip;
        actionGripRight.action.canceled -= OnReleaseRightGrip;
        actionGripLeft.action.started -= OnPressLeftGrip;
        actionGripLeft.action.canceled -= OnReleaseLeftGrip;
        actionTriggerRight.action.started -= OnPressRightTrigger;
        actionTriggerRight.action.canceled -= OnReleaseRightTrigger;
        actionTriggerLeft.action.started -= OnPressLeftTrigger;
        actionTriggerLeft.action.canceled -= OnReleaseLeftTrigger;
    }
    
    private void OnPressRightGrip(CallbackContext ctx) => PressGrip(directInteractorRight);
    private void OnPressLeftGrip(CallbackContext ctx) => PressGrip(directInteractorLeft);
    private void OnReleaseRightGrip(CallbackContext ctx) => ReleaseGrip(directInteractorRight);
    private void OnReleaseLeftGrip(CallbackContext ctx) => ReleaseGrip(directInteractorLeft);

    private void OnPressRightTrigger(CallbackContext ctx) => PressTrigger(directInteractorRight);
    private void OnPressLeftTrigger(CallbackContext ctx) => PressTrigger(directInteractorLeft);
    private void OnReleaseRightTrigger(CallbackContext ctx) => ReleaseTrigger(directInteractorRight);
    private void OnReleaseLeftTrigger(CallbackContext ctx) => ReleaseTrigger(directInteractorLeft);

    private void PressGrip(XRDirectInteractor interactor)
    {
        //Debug.Log("Press Grip");
        interactor.interactablesHovered.ForEach(
            (IXRHoverInteractable i) => {               
                if (i is IBaseInteractable b) 
                    b.OnGripStart();
            }
       );
    }

    private void ReleaseGrip(XRDirectInteractor interactor)
    {
        //Debug.Log("Release grip");
        interactor.interactablesHovered.ForEach(
            (IXRHoverInteractable i) => {               
                if (i is IBaseInteractable b) 
                    b.OnGripEnd();
            }
       );
    }

    private void PressTrigger(XRDirectInteractor interactor)
    {
        //Debug.Log("Press trigger");
        interactor.interactablesHovered.ForEach(
            (IXRHoverInteractable i) => {               
                if (i is IBaseInteractable b) 
                    b.OnTriggerStart();
            }
       );
    }

    private void ReleaseTrigger(XRDirectInteractor interactor)
    {
        //Debug.Log("Release trigger");
        interactor.interactablesHovered.ForEach(
            (IXRHoverInteractable i) => {               
                if (i is IBaseInteractable b) 
                    b.OnTriggerEnd();
            }
       );
    }




}
