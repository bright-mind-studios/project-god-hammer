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

    public float cooldownrock = 5f;

    public bool rock_enabled;

    private AudioSource _audioSource;
    
    private void Start() {
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator cooldownRoutine(){
        rock_enabled = false;
        yield return new WaitForSeconds(cooldownrock);
        rock_enabled = true;

    }

    private void OnCollisionEnter(Collision other)
    {
        MetalRock rock = other.gameObject.GetComponent<MetalRock>();        

        if (Vector3.Magnitude(rb.velocity) < neededSpeed)
            return;
        
        _audioSource.Play();
        
        if(rock != null && rock_enabled)
        {
            StartCoroutine(cooldownRoutine());
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
