using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] InputActionReference actionGrip;
    [SerializeField] InputActionReference actionPinch;
    private Animator handAnimator;
    private void Awake()
    {        
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable() {
        actionGrip.action.performed += GripPress;
        actionPinch.action.performed += TriggerPress;
    }

    private void OnDisable() {
        actionGrip.action.performed -= GripPress;
        actionPinch.action.performed -= TriggerPress;
    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }
    
    private void TriggerPress(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

}
