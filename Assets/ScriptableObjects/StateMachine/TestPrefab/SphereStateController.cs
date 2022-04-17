using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereStateController : BaseStateController
{
    [HideInInspector] public bool orderingGreen;

    private void Awake()
    {
        InitializeStateMachine(true);
    }

    public override void InitializeStateMachine(bool activate)
    {
        base.InitializeStateMachine(activate);
        orderingGreen = false;
    }
}
