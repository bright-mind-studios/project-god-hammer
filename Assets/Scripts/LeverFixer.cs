using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFixer : MonoBehaviour
{
    public ConfigurableJoint joint;
    public Vector3 offset;

    private void Start() 
    {
        offset = joint.connectedAnchor- transform.position;    
    }
    
    private void Update() 
    {
        joint.connectedAnchor = transform.position + offset; 
    }
}
