using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStation : MonoBehaviour
{
    [SerializeField] private MetalRock metalRock;
    [SerializeField] private Transform base_tf;

    public float time = 8f;
    public float speed = 90f;

    [ContextMenu("metal")]
    public void GenerateMetalRock()
    {
        StartCoroutine(rotation());
    }

    public void GenerateTree()
    {

    }

    private IEnumerator rotation()
    {
        metalRock.active();
        var current_time = 0f;
        var delta = 1f / time;
        while(current_time < time)
        {
            current_time += Time.deltaTime;
            base_tf.rotation = Quaternion.AngleAxis(current_time * speed, Vector3.up);
            yield return null;
        }
        base_tf.rotation = Quaternion.AngleAxis(0, Vector3.up);
        metalRock.hide();

    }


}
