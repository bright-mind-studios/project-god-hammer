using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ResetInteractables : MonoBehaviour
{
    XRGrabInteractable grabInteractable;

    [SerializeField] Vector3 reset_point;
    [SerializeField] float resetDelayTime;

    protected bool shouldReturnHome { get; set;}
    bool isController;

    private void Awake() {
        grabInteractable = GetComponent<XRGrabInteractable>();
        reset_point = transform.position;
        shouldReturnHome = true;
    }

    private void OnEnable() {
        grabInteractable.selectExited.AddListener(OnSelectExit);
        grabInteractable.selectEntered.AddListener(OnSelect);
    }

    private void OnDisable() {
        grabInteractable.selectExited.AddListener(OnSelectExit);
        grabInteractable.selectEntered.AddListener(OnSelect);
    }

    private void OnSelect(SelectEnterEventArgs arg0) => CancelInvoke("ReturnHome");
    private void OnSelectExit(SelectExitEventArgs arg0) => Invoke(nameof(ReturnHome), resetDelayTime);

    protected virtual void ReturnHome()
    {
        if(shouldReturnHome) transform.position = reset_point;
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other) 
    {
        if(ControllerCheck(other.gameObject)) return;

        var socketInteractor = other.gameObject.GetComponent<XRSocketInteractor>();

        if(socketInteractor == null) 
            shouldReturnHome = true;
        
        else if(socketInteractor.CanSelect(grabInteractable))
        {
            shouldReturnHome = false;
        }
        else
            shouldReturnHome = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        if (ControllerCheck(other.gameObject))
            return;
        shouldReturnHome = true;
        
    }

    bool ControllerCheck(GameObject collideObject)
    {
        return collideObject.gameObject.GetComponent<XRBaseController>() != null ? true : false;
    }
}
