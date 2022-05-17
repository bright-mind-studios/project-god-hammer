using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteractable : TouchInteractable
{
    public UnityAction OnPressButton;
    private Vector3 starPos; 
    [SerializeField] private Transform target;

    private float offset = 0.5f;

    protected override void Init()
    {
        starPos = target.localPosition;
    }

    public override void OnHoverEnter(HoverEnterEventArgs args)
    {
        target.localPosition = starPos + Vector3.down * offset;
        OnPressButton?.Invoke();
    }

    public override void OnHoverExit(HoverExitEventArgs args){
       target.localPosition = starPos;
    }
}
