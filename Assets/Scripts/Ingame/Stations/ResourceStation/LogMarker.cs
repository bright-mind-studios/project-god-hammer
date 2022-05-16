using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMarker : MonoBehaviour
{
    
    [SerializeField] Transform top, bottom;

    private void Update()
    {
        gameObject.layer = transform.parent.gameObject.layer;
    }

    public void RecalculatePosition()
    {
        float random = Random.Range(0f, 1f);
        transform.position = Vector3.Lerp(bottom.position, top.position, random);
    }
}
