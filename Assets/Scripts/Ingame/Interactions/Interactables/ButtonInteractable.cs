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

    private float offset = 0.01f;

    protected override void Init()
    {
        starPos = target.position;
    }

    public override void OnHoverEnter(HoverEnterEventArgs args){
        target.position = starPos + Vector3.down * offset;
        OnPressButton?.Invoke();
    }

    public override void OnHoverExit(HoverExitEventArgs args){
       target.position = starPos;
    }
}
