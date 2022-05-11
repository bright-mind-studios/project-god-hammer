using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeInteractable : GrabInteractable
{
    public float neededSpeed = 1.0f;
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other) 
    {
        //Debug.Log(Vector3.Magnitude(rb.velocity));
        if (Vector3.Magnitude(rb.velocity) < neededSpeed)
            return;

        MetalFragment collisionMetalFragment = other.gameObject.GetComponent<MetalFragment>();
        if(collisionMetalFragment != null)
        {
            Debug.Log(collisionMetalFragment.metal);
            Destroy(other.gameObject);
            
        }   
    }

}
