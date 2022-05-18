using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class OffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;
    private GameObject _attach;

    protected override void Awake()
    {
        base.Awake();
        _attach = new GameObject("Attach");
        _attach.transform.SetParent(transform, false);
        attachTransform = _attach.transform;
    }

    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        StoreInteractor(interactor);
        if (!(interactor is XRSocketInteractor)) MatchAttachmentPoints(interactor);
    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        ResetAttachmentPoints(interactor);
        if (!(interactor is XRSocketInteractor)) ClearInteractor(interactor);
    }

    private void ResetAttachmentPoints(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }

    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}
