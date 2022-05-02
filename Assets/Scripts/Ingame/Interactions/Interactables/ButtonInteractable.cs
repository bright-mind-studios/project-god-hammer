using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonInteractable : TouchInteractable
{
    private Vector3 starPos; 
    [SerializeField] private Transform target;
    [SerializeField] private float offset;

    public event Action OnPressButton;

    protected override void Init()
    {
        starPos = transform.position;
    }

    public override void OnHoverEnter(HoverEnterEventArgs args){
        target.position = starPos + Vector3.down * offset;
        OnPressButton();
    }

    public override void OnHoverExit(HoverExitEventArgs args){
       target.position = starPos;
    }
}
