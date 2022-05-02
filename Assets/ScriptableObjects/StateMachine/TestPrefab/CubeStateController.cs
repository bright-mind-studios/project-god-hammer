using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStateController : BaseStateController
{
    [HideInInspector] public bool isBeenTouched;

    private void Awake()
    {
        InitializeStateMachine(true);
    }

    public override void InitializeStateMachine(bool activate)
    {
        base.InitializeStateMachine(activate);
        isBeenTouched = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        isBeenTouched = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isBeenTouched = false;
    }
}
