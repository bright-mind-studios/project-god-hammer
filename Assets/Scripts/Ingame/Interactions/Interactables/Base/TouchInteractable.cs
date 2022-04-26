using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class TouchInteractable : XRSimpleInteractable, IBaseInteractable
{
    private bool _grip, _trigger;
    public bool IsOnGrip { get => _grip; set => _grip = value; }
    public bool IsOnTrigger { get => _trigger; set => _trigger = value; }

    protected override void Awake() {
        base.Awake();
        Init();
    }
    protected override void OnEnable() {
        base.OnEnable();
        hoverEntered.AddListener(OnHoverEnter);
        hoverExited.AddListener(OnHoverExit);
    }

    protected override void OnDisable() {
        base.OnDisable();
        hoverEntered.RemoveAllListeners();
        hoverExited.RemoveAllListeners();
    }

    protected virtual void Init() {}

    public virtual void OnHoverEnter(HoverEnterEventArgs args) {}
    public virtual void OnHoverExit(HoverExitEventArgs args) {}
    public virtual void OnGripStart() { IsOnGrip = true;}
    public virtual void OnGripEnd() { IsOnGrip = false;}
    public virtual void OnTriggerStart() { IsOnTrigger = true;}
    public virtual void OnTriggerEnd() { IsOnTrigger = false;}

    public virtual void ResetState(){ IsOnGrip = false; IsOnTrigger = false; }
}
