using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public float neededSpeed = 1.0f;
    private Rigidbody rb;

    [SerializeField] private GameObject metalOrePrefab;

    [SerializeField] private Transform spawnPoint;

    public Metal defaultMetal;

    public int max_rocks = 5;

    public float cooldownrock = 5f;

    private bool rock_enabled;
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public IEnumerator cooldownRoutine(){
        yield return new WaitForSeconds(5f);
        rock_enabled = true;

    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        
        //Debug.Log(Vector3.Magnitude(rb.velocity));
        MetalRock rock = other.gameObject.GetComponent<MetalRock>();        

        if (Vector3.Magnitude(rb.velocity) < neededSpeed)
            return;
        
        if(rock != null && rock_enabled)
        {
            rock_enabled = false;
            var metalspawned = Instantiate(metalOrePrefab, spawnPoint.position + Random.insideUnitSphere * .1f, spawnPoint.rotation);
            metalspawned.GetComponent<MetalItem>().SetMetal(defaultMetal);
        }

        MetalFragment collisionMetalFragment = other.gameObject.GetComponent<MetalFragment>();
        if(collisionMetalFragment != null)
        {
            Destroy(other.gameObject); 
            var metalspawned = Instantiate(metalOrePrefab, spawnPoint.position + Random.insideUnitSphere * .1f, spawnPoint.rotation);
            metalspawned.GetComponent<MetalItem>().SetMetal(collisionMetalFragment.metal);
        }   

        
    }

}