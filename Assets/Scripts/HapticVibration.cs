using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticVibration : MonoBehaviour
{
    private XRController xr;
    void Start()
    {
        xr = (XRController) GameObject.FindObjectOfType(typeof(XRController));
    }

    public void ActivateHaptic()
    {
        xr.SendHapticImpulse(2, 2);
        
    }
}
