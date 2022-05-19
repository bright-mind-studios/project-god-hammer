using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float neededSpeed = 1.0f;
    private Rigidbody rb;

    private AudioSource _audioSource;

    [SerializeField] private GameObject fireWoodItemPrefab;
    [SerializeField] private Transform spawnPoint;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        
        if (Vector3.Magnitude(rb.velocity) < neededSpeed)
            return;

        _audioSource.Play();
        
        LogMarker marker = other.gameObject.GetComponent<LogMarker>();
        if(marker != null)
        {
            var metalspawned = Instantiate(fireWoodItemPrefab, spawnPoint.position + Random.insideUnitSphere * .1f, spawnPoint.rotation);
            marker.RecalculatePosition();
        }
    }
}
